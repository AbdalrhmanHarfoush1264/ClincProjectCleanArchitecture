using ClincProject.Core.Features.Documents.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void EditDocumentMapping()
        {
            CreateMap<EditDocumentCommand, Document>().ForMember(dest => dest.DocumentId,
                opt => opt.MapFrom(src => src.Id));

        }
    }
}
