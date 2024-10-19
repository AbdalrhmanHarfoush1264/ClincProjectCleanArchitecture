using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Doctors.Queries.Response;
using MediatR;

namespace ClincProject.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorsListQuery : IRequest<CusResponse<List<GetDoctorsListResponse>>>
    {

    }
}
