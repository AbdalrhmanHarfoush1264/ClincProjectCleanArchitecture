using ClincProject.Core.Features.Patients.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Patients
{
    public partial class PatientProfile
    {

        public void GetPatientByIdMapping()
        {
            CreateMap<Patient, GetPatientByIdResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.PatientId));
        }
    }
}
