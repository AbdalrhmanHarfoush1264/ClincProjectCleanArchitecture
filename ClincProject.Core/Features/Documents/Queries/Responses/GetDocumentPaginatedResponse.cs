namespace ClincProject.Core.Features.Documents.Queries.Responses
{
    public class GetDocumentPaginatedResponse : GetDocumentListResponse
    {

        public GetDocumentPaginatedResponse(int id, string documentname, DateOnly timecreated,
            string details, string documenttype, string doctor)
        {
            Id = id;
            DocumentName = documentname;
            TimeCreated = timecreated;
            Details = details;
            DocumentType = documenttype;
            Doctor = doctor;
        }
    }
}
