using ClincProject.Core.Features.PatientCases.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.PatientCases
{
    public partial class PatientCaseProfile
    {
        public void GetPatientCaseByIdMapping()
        {
            CreateMap<PatientCase, GetSinglePatientCaseResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PatientCaseId))
                 .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.HasValue ?
                new DateOnly(src.EndTime.Value.Year, src.EndTime.Value.Month, src.EndTime.Value.Day)
                : (DateOnly?)null))
                 .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));
        }
    }
}
