using ClincProject.Core.Features.Doctors.Queries.Response;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetSingleDoctorMapping()
        {
            CreateMap<Doctor, GetSingleDoctorResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DoctorId));
        }
    }
}
