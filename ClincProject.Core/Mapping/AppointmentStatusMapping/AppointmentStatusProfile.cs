using AutoMapper;

namespace ClincProject.Core.Mapping.AppointmentStatusMapping
{
    public partial class AppointmentStatusProfile : Profile
    {

        public AppointmentStatusProfile()
        {
            GetAppointmentStatusListMapping();
            GetSingleAppointmentStatusMapping();
        }
    }
}
