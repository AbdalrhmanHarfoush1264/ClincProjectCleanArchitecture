using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Commands.Models
{
    public class AddStatusHistoryCommand : IRequest<CusResponse<string>>
    {
        public string? details { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentStatusID { get; set; }
    }
}
