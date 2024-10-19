using ClincProject.Core.Features.Patients.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.Patients.Queries.Models
{
    public class GetPatientsPaginatedListQuery : IRequest<PaginatedResult<GetPatientsPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Serach { get; set; }
    }
}
