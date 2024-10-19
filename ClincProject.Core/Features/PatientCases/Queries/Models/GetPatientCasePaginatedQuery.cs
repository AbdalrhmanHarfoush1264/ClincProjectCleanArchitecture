using ClincProject.Core.Features.PatientCases.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.PatientCases.Queries.Models
{
    public class GetPatientCasePaginatedQuery : IRequest<PaginatedResult<GetPatientCasePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? search { get; set; }

    }
}
