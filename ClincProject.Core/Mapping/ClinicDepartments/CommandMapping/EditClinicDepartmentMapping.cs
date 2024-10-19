using ClincProject.Core.Features.ClinicDepartments.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile
    {
        public void EditClinicDepartmentMapping()
        {
            CreateMap<EditClinicDepartmentCommand, ClinicDepartment>()
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
