using ClincProject.Core.Features.DocumentTypes.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void EditDocumentTypeMapping()
        {
            CreateMap<EditDocumentTypeCommand, DocumentType>().ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
