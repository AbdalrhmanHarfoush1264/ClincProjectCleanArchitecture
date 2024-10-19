using ClincProject.Core.Features.DocumentTypes.Queriers.Response;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void GetDocumentTypeListMapping()
        {
            CreateMap<DocumentType, GetDocumentTypeListResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentTypeId));
        }
    }
}
