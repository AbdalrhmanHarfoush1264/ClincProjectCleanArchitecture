using ClincProject.Core.Features.Patients.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void EditPatientMapping()
        {
            CreateMap<EditPatientCommand, Patient>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
