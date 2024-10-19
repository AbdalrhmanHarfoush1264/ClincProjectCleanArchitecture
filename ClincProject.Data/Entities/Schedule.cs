namespace ClincProject.Data.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }

        public int EmployeeSchedulesId { get; set; }
        public EmployeeSchedules EmployeeSchedules { get; set; } = null!;
    }
}
