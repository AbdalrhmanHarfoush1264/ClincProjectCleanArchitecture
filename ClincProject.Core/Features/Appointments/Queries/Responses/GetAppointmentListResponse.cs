namespace ClincProject.Core.Features.Appointments.Queries.Responses
{
    public class GetAppointmentListResponse
    {
        public int Id { get; set; }
        public DateOnly TimeCreated { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string Patient { get; set; } = null!;
        public string Doctor { get; set; } = null!;
        public decimal TotalCost { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; } = null!;
    }
}
