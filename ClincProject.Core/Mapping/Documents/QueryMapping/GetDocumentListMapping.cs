using ClincProject.Core.Features.Documents.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void GetDocumentListMapping()
        {
            CreateMap<Document, GetDocumentListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentId))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Appointment.Doctor.FirstName + " " + src.Appointment.Doctor.LastName))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.TypeName));

        }
    }
}
