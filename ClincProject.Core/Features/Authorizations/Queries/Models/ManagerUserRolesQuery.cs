using ClincProject.Core.BasesCore;
using ClincProject.Data.Helpers;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Queries.Models
{
    public class ManagerUserRolesQuery : IRequest<CusResponse<ManagerUserRolesResponse>>
    {
        public ManagerUserRolesQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
