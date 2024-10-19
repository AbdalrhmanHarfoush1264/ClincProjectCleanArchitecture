using ClincProject.Core.Features.Doctors.Queries.Response;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorsPaginatedQuery : IRequest<PaginatedResult<GetDoctorsPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
