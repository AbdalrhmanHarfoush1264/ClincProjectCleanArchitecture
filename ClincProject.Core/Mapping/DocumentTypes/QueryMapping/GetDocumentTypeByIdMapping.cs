using ClincProject.Core.Features.DocumentTypes.Queriers.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void GetDocumentTypeByIdMapping()
        {
            CreateMap<DocumentType, GetDocumentTypeByIdResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentTypeId));
        }
    }
}
