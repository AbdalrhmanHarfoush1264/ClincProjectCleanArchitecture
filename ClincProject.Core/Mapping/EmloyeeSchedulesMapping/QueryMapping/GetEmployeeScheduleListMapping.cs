using ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.EmloyeeSchedulesMapping
{
    public partial class EmployeeScheduleProfile
    {
        public void GetEmployeeScheduleListMapping()
        {
            CreateMap<EmployeeSchedules, GetEmployeeScheduleListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeSchedulesId))
                .ForMember(dest => dest.doctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.departmentName, opt => opt.MapFrom(src => src.ClinicDepartment.DepartmentName));
        }

    }
}
