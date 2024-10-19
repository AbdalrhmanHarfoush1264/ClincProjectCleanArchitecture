namespace ClincProject.Data.Entities
{
    public class PatientCase
    {
        public int PatientCaseId { get; set; }
        public DateOnly StartTime { get; set; }
        public DateOnly? EndTime { get; set; }
        public bool InProgress { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AmountPaid { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public ICollection<Appointment>? Appointments { get; set; } = new HashSet<Appointment>();
    }
}
