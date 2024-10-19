using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Commands.Models
{
    public class EditStatusHistoryCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public string? details { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentStatusID { get; set; }
    }
}
