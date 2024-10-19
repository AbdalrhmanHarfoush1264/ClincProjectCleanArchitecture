using ClincProject.Core.BasesCore;
using ClincProject.Core.Features.Documents.Queries.Responses;
using MediatR;

namespace ClincProject.Core.Features.Documents.Queries.Models
{
    public class GetDocumentListQuery : IRequest<CusResponse<List<GetDocumentListResponse>>>
    {

    }
}
