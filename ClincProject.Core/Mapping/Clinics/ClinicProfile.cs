using AutoMapper;

namespace ClincProject.Core.Mapping.Clinics
{
    public partial class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            AddClinicMapping();
            EditClinicMapping();
            GetClinicListMapping();

        }
    }
}
