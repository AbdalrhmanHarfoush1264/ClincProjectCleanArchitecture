using ClincProject.Core.Features.Documents.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void AddDocumentMapping()
        {
            CreateMap<AddDocumentCommand, Document>();

        }
    }
}
