using ClincProject.Core.BasesCore;
using ClincProject.Data.Helpers;
using MediatR;

namespace ClincProject.Core.Features.Authentications.Commands.Models
{
    public class SignInCommand : IRequest<CusResponse<JwtAuthResponse>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
