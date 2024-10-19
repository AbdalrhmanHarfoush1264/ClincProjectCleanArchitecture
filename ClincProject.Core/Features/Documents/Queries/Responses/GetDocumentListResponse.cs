namespace ClincProject.Core.Features.Documents.Queries.Responses
{
    public class GetDocumentListResponse
    {
        public int Id { get; set; }
        public string DocumentName { get; set; } = null!;
        public DateOnly TimeCreated { get; set; }
        public string? Details { get; set; }
        public string DocumentType { get; set; } = null!;
        public string Doctor { get; set; } = null!;
    }
}
