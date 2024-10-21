using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Authorizations.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Authorizations.Queries.Models
{
    public class GetRoleListQuery : IRequest<CusResponse<List<GetRoleListResponse>>>
    {

    }
}
