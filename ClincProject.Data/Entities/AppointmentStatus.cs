namespace ClincProject.Data.Entities
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public ICollection<StatusHistory>? StatusHistories { get; set; } = new HashSet<StatusHistory>();
        public ICollection<Appointment>? Appointments { get; set; } = new HashSet<Appointment>();

    }
}
