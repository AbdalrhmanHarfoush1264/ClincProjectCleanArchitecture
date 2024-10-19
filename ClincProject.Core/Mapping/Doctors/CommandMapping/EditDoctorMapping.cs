using ClincProject.Core.Features.Doctors.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void EditDoctorMapping()
        {
            CreateMap<EditDoctorCommand, Doctor>().ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
