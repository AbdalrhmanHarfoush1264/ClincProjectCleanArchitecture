using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.AppointmentStatuses.Queries.Models
{
    public class GetAppointmentStatusLByIdQuery : IRequest<CusResponse<GetSingleAppointmentStatusResponse>>
    {
        public int Id { get; set; }
        public GetAppointmentStatusLByIdQuery(int id)
        {
            Id = id;
        }
    }
}
