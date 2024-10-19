using AutoMapper;

namespace ClincProject.Core.Mapping.Schedules
{
    public partial class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            AddScheduleMapping();
            EditScheduleMapping();
            GetScheduleListMapping();
            GetScheduleByIdMapping();
        }
    }
}
