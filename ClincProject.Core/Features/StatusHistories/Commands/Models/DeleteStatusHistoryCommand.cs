using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.StatusHistories.Commands.Models
{
    public class DeleteStatusHistoryCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }
        public DeleteStatusHistoryCommand(int id)
        {
            Id = id;
        }
    }
}
