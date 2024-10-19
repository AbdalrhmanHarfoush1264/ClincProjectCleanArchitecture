using ClincProject.Core.BasesCore;
using MediatR;

namespace ClincProject.Core.Features.Appointments.Commands.Models
{
    public class AddAppointmentCommand : IRequest<CusResponse<string>>
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientCaseId { get; set; }
        public int AppointmentStatusId { get; set; }
    }
}
