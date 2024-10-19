using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Appointments.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Appointments.Queries.Models
{
    public class GetAppointmentListQuery : IRequest<CusResponse<List<GetAppointmentListResponse>>>
    {

    }
}
