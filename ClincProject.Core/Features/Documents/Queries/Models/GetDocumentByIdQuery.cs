using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Documents.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Documents.Queries.Models
{
    public class GetDocumentByIdQuery : IRequest<CusResponse<GetSingleDocumentResponse>>
    {

        public int Id { get; set; }
        public GetDocumentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
