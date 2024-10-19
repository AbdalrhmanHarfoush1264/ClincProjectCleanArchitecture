using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Schedules.Commands.Models
{
    public class DeleteScheduleCommand : IRequest<CusResponse<string>>
    {

        public int Id { get; set; }
        public DeleteScheduleCommand(int ID)
        {
            Id = ID;
        }
    }
}
