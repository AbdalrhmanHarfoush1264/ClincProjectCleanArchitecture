namespace ClincProject.Data.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateOnly TimeCreated { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }


        public int PatientCaseId { get; set; }
        public PatientCase PatientCase { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int AppointmentStatusId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; } = null!;

        public ICollection<StatusHistory>? StatusHistories { get; set; } = new HashSet<StatusHistory>();
        public ICollection<Document>? Documents { get; set; } = new HashSet<Document>();
    }
}
