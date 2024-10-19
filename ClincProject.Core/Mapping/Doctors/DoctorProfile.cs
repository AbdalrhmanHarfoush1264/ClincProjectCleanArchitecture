using AutoMapper;

namespace ClincProject.Core.Mapping.Doctors
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            AddDoctorMapping();
            EditDoctorMapping();
            GetDoctorsListMapping();
            GetSingleDoctorMapping();
            GetDoctorsPaginatedMapping();
        }
    }
}
