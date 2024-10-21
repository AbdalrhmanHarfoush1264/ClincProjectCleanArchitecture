using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Authentications.Queries.Models;
using ClincProject.Service.Abstracts;
using MediatR;

namespace ClincProject.Core.Features.Authentications.Queries.Handlers
{
    public class AuthenticationQueryHandler : CusResponseHandler,
        IRequestHandler<AuthorizeUserQuery, CusResponse<string>>
    {
        #region Fields
        private readonly ICusAuthenticationService _cusAuthenticationService;

        #endregion

        #region Constructors
        public AuthenticationQueryHandler(ICusAuthenticationService cusAuthenticationService)
        {
            _cusAuthenticationService = cusAuthenticationService;
        }
        #endregion

        #region Functions
        public async Task<CusResponse<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cusAuthenticationService.ValidateToken(request.Accesstoken);
                if (result == "NotExpired")
                {
                    return Success("this token is not expired.");
                }

                return Unauthorized<string>("this token is expired.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion
    }
}
