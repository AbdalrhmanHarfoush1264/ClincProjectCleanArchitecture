using ClincProject.Core.Features.Patients.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void AddPatienMapping()
        {
            CreateMap<AddPatientCommand, Patient>();
        }
    }
}
