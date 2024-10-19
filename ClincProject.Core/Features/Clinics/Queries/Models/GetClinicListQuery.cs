using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Clinics.Queries.Response;
using MediatR;

namespace ClincProject.Core.Features.Clinics.Queries.Models
{
    public class GetClinicListQuery : IRequest<CusResponse<List<GetClinicListResponse>>>
    {

    }
}
