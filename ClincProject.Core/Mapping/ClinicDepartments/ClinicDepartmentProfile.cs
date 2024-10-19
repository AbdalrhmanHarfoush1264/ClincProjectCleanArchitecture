using AutoMapper;

namespace ClincProject.Core.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile : Profile
    {
        public ClinicDepartmentProfile()
        {
            AddClinicDepartmentMapping();
            EditClinicDepartmentMapping();
            GetClinicDepartmentListMapping();
            GetClinicDepartmentByIdMapping();
        }
    }
}
