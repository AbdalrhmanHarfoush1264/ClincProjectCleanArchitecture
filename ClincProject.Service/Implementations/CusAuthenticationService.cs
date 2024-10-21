using ClincProject.Data.Entities.Identities;
using ClincProject.Data.Helpers;
using ClincProject.Infrastructure.InfrastructureBases;
using ClincProject.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ClincProject.Service.Implementations
{
    public class CusAuthenticationService : ICusAuthenticationService
    {
        #region Fileds

        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<CusAuthenticationService> _logger;

        #endregion

        #region Constructors

        public CusAuthenticationService(UserManager<User> userManager,
            JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository,
            ILogger<CusAuthenticationService> logger)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _logger = logger;
        }

        #endregion

        #region Main_Functions
        public async Task<JwtAuthResponse> GetJwtToken(User user)
        {
            try
            {


                //Generate Jwt Token..
                var (jwtToken, accessToken) = await GenerateJwtToken(user);

                //Generate Resfresh Token & Save To Database
                var refreshToken = GetRefreshToken(user.UserName!);
                var userRefreshToken = new UserRefreshToken
                {
                    AddedTime = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate),
                    IsUsed = true,
                    IsRevoked = false,
                    JwtId = jwtToken.Id,
                    RefreshToken = refreshToken.TokenString,
                    Token = accessToken,
                    UserId = user.Id
                };
                await _refreshTokenRepository.AddAsync(userRefreshToken);

                //return response
                var response = new JwtAuthResponse
                {
                    AccessToken = accessToken,
                    refreshToken = refreshToken
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetJwtToken");
                throw;
            }
        }

        public async Task<JwtAuthResponse> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            try
            {
                var (jwtSecurityToken, newToken) = await GenerateJwtToken(user);

                var refreshTokenResult = new RefreshToken();
                refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.UserName))!.Value;
                refreshTokenResult.TokenString = refreshToken;
                refreshTokenResult.ExpireAt = (DateTime)expiryDate;

                var response = new JwtAuthResponse();
                response.AccessToken = newToken;
                response.refreshToken = refreshTokenResult;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetRefreshToken");
                throw;
            }

        }


        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshTken)
        {
            try
            {

                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                {
                    return ("AlgorithmIsWrong", null);
                }

                if (jwtToken.ValidTo > DateTime.UtcNow)
                {
                    return ("TokenIsRunning", null);
                }

                //Get UserId From Glaims in jwtToken
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "Id")!.Value;

                var userRefreshtoken = await _refreshTokenRepository.GetTableNoTracking()
                    .FirstOrDefaultAsync(x => x.Token == accessToken && x.RefreshToken == refreshTken
                    && x.UserId == int.Parse(userId));

                if (userRefreshtoken == null)
                {
                    return ("RefreshTokenNotFound", null);
                }

                if (userRefreshtoken.ExpiryDate < DateTime.UtcNow)
                {
                    userRefreshtoken.IsRevoked = true;
                    userRefreshtoken.IsUsed = false;
                    await _refreshTokenRepository.UpdateAsync(userRefreshtoken);
                    return ("RefreshTokenIsExpired", null);
                }

                var expiryDate = userRefreshtoken.ExpiryDate;
                return (userId, expiryDate);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in ValidateDetails");
                throw;
            }
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = _jwtSettings.ValidateIssure,
                    ValidIssuers = new[] { _jwtSettings.Issure },
                    ValidateIssuerSigningKey = _jwtSettings.ValidateIssureSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                    ValidateAudience = _jwtSettings.validateAudience,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateLifetime = _jwtSettings.ValidateLifeTime
                };

                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in ValidateToken");
                throw;
            }
        }
        #endregion

        #region Sub-Functions

        private async Task<(JwtSecurityToken, string)> GenerateJwtToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var Claims = GetClaims(user, roles.ToList());

            var jwtToken = new JwtSecurityToken(_jwtSettings.Issure, _jwtSettings.Audience,
                claims: Claims, expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
        private List<Claim> GetClaims(User user, List<string> roles)
        {
            //Add some properties to claims...
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.NameIdentifier,user.UserName!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(nameof(UserClaimsModel.PhoneNumber),user.PhoneNumber),
                new Claim(nameof(UserClaimsModel.Id),user.Id.ToString())
            };

            //Add roles to claims...
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };

            return refreshToken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        #endregion

    }
}
