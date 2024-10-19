using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.DocumentTypes.Queriers.Responses;
using MediatR;

namespace ClincProject.Core.Features.DocumentTypes.Queriers.Models
{
    public class GetDocumentTypeByIdQuery : IRequest<CusResponse<GetDocumentTypeByIdResponse>>
    {
        public GetDocumentTypeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
