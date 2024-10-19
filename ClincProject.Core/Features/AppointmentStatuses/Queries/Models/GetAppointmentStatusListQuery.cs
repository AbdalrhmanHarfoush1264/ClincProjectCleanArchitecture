using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.AppointmentStatuses.Queries.Models
{
    public class GetAppointmentStatusListQuery : IRequest<CusResponse<List<GetAppointmentStatusListResponse>>>
    {

    }
}
