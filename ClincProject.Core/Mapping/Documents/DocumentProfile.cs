using AutoMapper;

namespace ClincProject.Core.Mapping.Documents
{
    public partial class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            AddDocumentMapping();
            EditDocumentMapping();
            GetDocumentListMapping();
            GetDocumentByIdMapping();
        }
    }
}
