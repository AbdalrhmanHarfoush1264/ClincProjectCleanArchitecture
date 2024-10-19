using ClincProject.Core.Features.Clinics.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void AddClinicMapping()
        {
            CreateMap<AddClinicCommand, Clinic>();
        }

    }
}
