using AutoMapper;

namespace ClincProject.Core.Mapping.PatientCases
{
    public partial class PatientCaseProfile : Profile
    {

        public PatientCaseProfile()
        {
            AddPatientCaseMapping();
            EditPatientCaseMapping();
            GetPatientCaseListMapping();
            GetPatientCaseByIdMapping();
        }
    }
}
