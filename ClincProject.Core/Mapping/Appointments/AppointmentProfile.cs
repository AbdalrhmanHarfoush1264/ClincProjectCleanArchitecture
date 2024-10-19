using AutoMapper;

namespace ClincProject.Core.Mapping.Appointments
{
    public partial class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            AddAppointmentMapping();
            EditAppointmentMapping();
            GetAppointmentListMapping();
            GetAppointmentByIdMapping();
        }
    }
}
