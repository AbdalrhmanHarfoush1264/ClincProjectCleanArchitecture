using ClincProject.Core.Features.DocumentTypes.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void AddDocumentTypeMapping()
        {
            CreateMap<AddDocumentTypeCommand, DocumentType>();
        }
    }
}
