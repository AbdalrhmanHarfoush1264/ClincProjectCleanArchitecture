using ClincProject.Core.Features.ClinicDepartments.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentPaginatedQuery : IRequest<PaginatedResult<GetClinicDepartmentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
