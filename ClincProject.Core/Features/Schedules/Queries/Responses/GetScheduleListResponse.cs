namespace ClincProject.Core.Features.Schedules.Queries.Responses
{
    public class GetScheduleListResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }

        public string DoctorName { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;

    }
}
