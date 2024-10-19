using ClincProject.Core.Features.Documents.Queries.Responses;
using ClincProject.Core.Wappers;
using MediatR;

namespace ClincProject.Core.Features.Documents.Queries.Models
{
    public class GetDocumentPaginatedQuery : IRequest<PaginatedResult<GetDocumentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? DoctorName { get; set; }
        public string? TypeName { get; set; }
    }
}
