using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Schedules.Commands.Models
{
    public class AddScheduleCommand : IRequest<CusResponse<string>>
    {

        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int EmployeeSchedulesId { get; set; }
    }
}
