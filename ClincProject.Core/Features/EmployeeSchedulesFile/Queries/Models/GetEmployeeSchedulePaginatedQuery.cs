using ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeSchedulePaginatedQuery : IRequest<PaginatedResult<GetEmployeeSchedulePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsActive { get; set; }
    }
}
