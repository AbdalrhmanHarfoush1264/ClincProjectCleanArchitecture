using ClincProject.Core.Features.Schedules.Queries.Responses;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Schedules
{
    public partial class ScheduleProfile
    {
        public void GetScheduleByIdMapping()
        {
            CreateMap<Schedule, GetScheduleByIdResponse>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ScheduleId))
              .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.EmployeeSchedules.Doctor.FirstName + " " + src.EmployeeSchedules.Doctor.LastName))
              .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.EmployeeSchedules.ClinicDepartment.DepartmentName));
        }
    }
}
