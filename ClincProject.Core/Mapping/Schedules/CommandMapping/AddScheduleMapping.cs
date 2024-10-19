using ClincProject.Core.Features.Schedules.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Schedules
{
    public partial class ScheduleProfile
    {
        public void AddScheduleMapping()
        {
            CreateMap<AddScheduleCommand, Schedule>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => new DateOnly(src.Date.Year, src.Date.Month, src.Date.Day)))
                .ForMember(dest => dest.TimeStart, opt => opt.MapFrom(src => new TimeOnly(src.TimeStart.Hour, src.TimeStart.Minute)))
                .ForMember(dest => dest.TimeEnd, opt => opt.MapFrom(src => new TimeOnly(src.TimeEnd.Hour, src.TimeEnd.Minute)));
        }
    }
}
