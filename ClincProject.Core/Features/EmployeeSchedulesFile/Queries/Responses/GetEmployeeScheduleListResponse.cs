namespace ClincProject.Core.Features.EmployeeSchedulesFile.Queries.Responses
{
    public class GetEmployeeScheduleListResponse
    {
        public int Id { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
        public bool IsActive { get; set; }
        public string doctorName { get; set; } = null!;
        public string departmentName { get; set; } = null!;
    }
}
