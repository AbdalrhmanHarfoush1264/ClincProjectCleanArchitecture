using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Commands.Models
{
    public class AddRoleCommand : IRequest<CusResponse<string>>
    {
        public string roleName { get; set; } = null!;
    }
}
