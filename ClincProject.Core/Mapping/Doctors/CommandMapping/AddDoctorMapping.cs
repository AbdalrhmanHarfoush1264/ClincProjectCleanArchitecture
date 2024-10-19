using ClincProject.Core.Features.Doctors.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {

        public void AddDoctorMapping()
        {
            CreateMap<AddDoctorCommand, Doctor>();
        }
    }
}
