using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Documents.Commands.Models
{
    public class DeleteDocumentCommand : IRequest<CusResponse<string>>
    {
        public int Id { get; set; }

        public DeleteDocumentCommand(int id)
        {
            Id = id;
        }
    }
}
