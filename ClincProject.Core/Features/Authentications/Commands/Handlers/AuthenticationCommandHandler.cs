using AutoMapper;
using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Authentications.Commands.Models;
using ClincProject.Data.Entities.Identities;
using ClincProject.Data.Helpers;
using ClincProject.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClincProject.Core.Features.Authentications.Commands.Handlers
{
    public class AuthenticationCommandHandler : CusResponseHandler,
        IRequestHandler<SignInCommand, CusResponse<JwtAuthResponse>>,
        IRequestHandler<RefreshTokenCommand, CusResponse<JwtAuthResponse>>
    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICusAuthenticationService _cusAuthenticationService;
        #endregion

        #region Constructors
        public AuthenticationCommandHandler(UserManager<User> userManager,
            SignInManager<User> signInManager, IMapper mapper, ICusAuthenticationService cusAuthenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _cusAuthenticationService = cusAuthenticationService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<JwtAuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                    return NotFound<JwtAuthResponse>("User with this username not found!");

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!signInResult.Succeeded)
                {
                    return BadRequest<JwtAuthResponse>("Password is't correct.");
                }

                var accessToken = await _cusAuthenticationService.GetJwtToken(user);
                return Success(accessToken);
            }
            catch (Exception ex)
            {
                return ServerError<JwtAuthResponse>(ex.Message);
            }
        }

        public async Task<CusResponse<JwtAuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jwtToken = _cusAuthenticationService.ReadJwtToken(request.AccessToken);
                var userIdAndExpiryDate = await _cusAuthenticationService.ValidateDetails(jwtToken,
                    request.AccessToken, request.RefreshToken);

                switch (userIdAndExpiryDate)
                {
                    case ("AlgorithmIsWrong", null):
                        return Unauthorized<JwtAuthResponse>("Algorithm is wrong.");

                    case ("TokenIsRunning", null):
                        return Unauthorized<JwtAuthResponse>("Toekn is not expired.");

                    case ("RefreshTokenNotFound", null):
                        return Unauthorized<JwtAuthResponse>("Refresh token not found.");

                    case ("RefreshTokenIsExpired", null):
                        return Unauthorized<JwtAuthResponse>("Refresh token is expired.");
                }

                var (userId, ExpiryDate) = userIdAndExpiryDate;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound<JwtAuthResponse>("User not found!");

                var result = await _cusAuthenticationService.GetRefreshToken(user, jwtToken, ExpiryDate, request.RefreshToken);
                return Success(result);
            }
            catch (Exception ex)
            {
                return ServerError<JwtAuthResponse>(ex.Message);
            }
        }
        #endregion


    }
}
