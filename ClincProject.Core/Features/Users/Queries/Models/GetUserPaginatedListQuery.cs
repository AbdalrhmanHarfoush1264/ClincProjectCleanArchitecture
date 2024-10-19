using ClincProject.Core.Features.Users.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.Users.Queries.Models
{
    public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
