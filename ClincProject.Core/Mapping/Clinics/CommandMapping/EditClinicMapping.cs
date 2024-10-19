using ClincProject.Core.Features.Clinics.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void EditClinicMapping()
        {
            CreateMap<EditClinicCommand, Clinic>().ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
