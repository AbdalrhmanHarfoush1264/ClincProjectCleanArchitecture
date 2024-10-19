namespace ClincProject.Data.Entities
{
    public class StatusHistory
    {
        public int StatusHistoryId { get; set; }
        public DateOnly StatusTime { get; set; }
        public string? details { get; set; }

        public int AppointmentStatusID { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; } = null!;

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
    }
}
