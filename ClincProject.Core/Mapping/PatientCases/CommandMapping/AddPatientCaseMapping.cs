using ClincProject.Core.Features.PatientCases.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.PatientCases
{
    public partial class PatientCaseProfile
    {
        public void AddPatientCaseMapping()
        {
            CreateMap<AddPatientCaseCommand, PatientCase>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => new DateOnly(src.StartTime.Year, src.StartTime.Month, src.StartTime.Day)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.HasValue ?
                new DateOnly(src.EndTime.Value.Year, src.EndTime.Value.Month, src.EndTime.Value.Day)
                : (DateOnly?)null));
        }
    }
}
