using ClincProject.Core.Features.ClinicDepartments.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile
    {
        public void AddClinicDepartmentMapping()
        {
            CreateMap<AddClinicDepartmentCommand, ClinicDepartment>();
        }
    }
}
