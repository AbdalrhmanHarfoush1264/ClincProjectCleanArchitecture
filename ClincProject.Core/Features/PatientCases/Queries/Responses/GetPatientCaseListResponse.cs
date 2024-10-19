namespace ClincProject.Core.Features.PatientCases.Queries.Responses
{
    public class GetPatientCaseListResponse
    {
        public int Id { get; set; }
        public DateOnly StartTime { get; set; }
        public DateOnly? EndTime { get; set; }
        public bool InProgress { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AmountPaid { get; set; }
        public string PatientName { get; set; } = null!;
    }
}
