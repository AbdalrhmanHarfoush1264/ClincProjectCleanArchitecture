using ClincProject.Core.Features.EmployeeSchedulesFile.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.EmloyeeSchedulesMapping
{
    public partial class EmployeeScheduleProfile
    {
        public void EditEmployeeScheduleMapping()
        {
            CreateMap<EditEmployeeScheduleCommand, EmployeeSchedules>()
                .ForMember(dest => dest.EmployeeSchedulesId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.clinicDepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.TimeFrom, opt => opt.MapFrom(src => new TimeOnly(src.TimeFrom.Hour, src.TimeFrom.Minute)))
                .ForMember(dest => dest.TimeTo, opt => opt.MapFrom(src => new TimeOnly(src.TimeTo.Hour, src.TimeTo.Minute)));

        }
    }
}
