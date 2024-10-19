using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.DocumentTypes.Commands.Models
{
    public class DeleteDocumentTypeCommand : IRequest<CusResponse<string>>
    {
        public DeleteDocumentTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
