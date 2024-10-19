using AutoMapper;

namespace ClincProject.Core.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            AddDocumentTypeMapping();
            EditDocumentTypeMapping();
            GetDocumentTypeListMapping();
            GetDocumentTypeByIdMapping();
        }
    }
}
