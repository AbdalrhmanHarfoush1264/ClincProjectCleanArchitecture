using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.AppointmentStatuses.Commands.Models
{
    public class AddAppointmentStatusCommand : IRequest<CusResponse<string>>
    {
        public string StatusName { get; set; } = null!;
    }
}
