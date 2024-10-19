using ClincProject.Core.Features.StatusHistories.Querires.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryPaginatedQuery : IRequest<PaginatedResult<GetStatusHistoryPaginatedResponse>>
    {
        public int PageNumer { get; set; }
        public int PageSize { get; set; }
        public string? statusName { get; set; }
    }
}
