using ClincProject.Core.Features.Schedules.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.Schedules.Queries.Models
{
    public class GetSchedulePaginatedQuery : IRequest<PaginatedResult<GetSchedulePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public DateTime? Date { get; set; }
    }
}
