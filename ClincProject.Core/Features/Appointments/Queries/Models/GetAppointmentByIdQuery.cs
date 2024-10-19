using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Appointments.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Appointments.Queries.Models
{
    public class GetAppointmentByIdQuery : IRequest<CusResponse<GetSingleAppointmentResponse>>
    {
        public int Id { get; set; }
        public GetAppointmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
