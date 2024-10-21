using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Commands.Models
{
    public class EditRoleCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public string roleName { get; set; } = null!;
    }
}
