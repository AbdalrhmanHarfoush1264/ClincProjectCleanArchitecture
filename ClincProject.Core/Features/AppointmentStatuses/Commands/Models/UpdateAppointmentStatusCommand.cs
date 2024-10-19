using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.AppointmentStatuses.Commands.Models
{
    public class UpdateAppointmentStatusCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public string statusName { get; set; } = null!;
    }
}
