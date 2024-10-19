using ClincProject.Core.Features.Appointments.Commands.Models;
using ClincProject.Data.Entities;

namespace ClincProject.Core.Mapping.Appointments
{
    public partial class AppointmentProfile
    {
        public void AddAppointmentMapping()
        {

            CreateMap<AddAppointmentCommand, Appointment>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => new TimeOnly(src.StartTime.Hour, src.StartTime.Minute)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.HasValue ?
                new TimeOnly(src.EndTime.Value.Hour, src.EndTime.Value.Minute, src.EndTime.Value.Second) :
                (TimeOnly?)null));
        }
    }
}
