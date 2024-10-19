using AutoMapper;

namespace ClincProject.Core.Mapping.Patients
{
    public partial class PatientProfile : Profile
    {

        public PatientProfile()
        {
            GetPatientListMapping();
            GetPatientByIdMapping();
            AddPatienMapping();
            EditPatientMapping();
        }
    }
}
