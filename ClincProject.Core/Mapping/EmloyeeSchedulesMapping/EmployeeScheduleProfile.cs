using AutoMapper;

namespace ClincProject.Core.Mapping.EmloyeeSchedulesMapping
{
    public partial class EmployeeScheduleProfile : Profile
    {
        public EmployeeScheduleProfile()
        {
            AddEmployeeScheduleMapping();
            EditEmployeeScheduleMapping();
            GetEmployeeScheduleListMapping();
            GetEmployeeScheduleByIdMapping();
        }
    }
}
