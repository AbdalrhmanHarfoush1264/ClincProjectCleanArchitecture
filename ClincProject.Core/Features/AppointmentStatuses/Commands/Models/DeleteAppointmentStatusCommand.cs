using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.AppointmentStatuses.Commands.Models
{
    public class DeleteAppointmentStatusCommand : IRequest<CusResponse<string>>
    {
        public int ID { get; set; }
        public DeleteAppointmentStatusCommand(int Id)
        {
            ID = Id;
        }
    }
}
