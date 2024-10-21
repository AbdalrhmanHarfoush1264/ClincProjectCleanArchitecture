using ClincProject.Core.BasesCore;
using ClincProject.Data.Helpers;
using MediatR;

namespace ClincProject.Core.Features.Authentications.Commands.Models
{
    public class RefreshTokenCommand : IRequest<CusResponse<JwtAuthResponse>>
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
