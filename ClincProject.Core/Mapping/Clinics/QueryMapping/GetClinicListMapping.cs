using ClincProject.Core.Features.Clinics.Queries.Response;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetClinicListMapping()
        {

            CreateMap<Clinic, GetClinicListResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClinicId));
        }
    }
}
