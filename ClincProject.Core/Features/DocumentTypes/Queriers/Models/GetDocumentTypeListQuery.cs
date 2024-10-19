using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.DocumentTypes.Queriers.Response;
using MediatR;

namespace ClincProject.Core.Features.DocumentTypes.Queriers.Models
{
    public class GetDocumentTypeListQuery : IRequest<CusResponse<List<GetDocumentTypeListResponse>>>
    {

    }
}
