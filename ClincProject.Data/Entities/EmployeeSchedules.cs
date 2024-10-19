namespace ClincProject.Data.Entities
{
    public class EmployeeSchedules
    {
        public int EmployeeSchedulesId { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
        public bool IsActive { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int clinicDepartmentId { get; set; }
        public ClinicDepartment ClinicDepartment { get; set; } = null!;


        public ICollection<Schedule>? Schedules { get; set; } = new HashSet<Schedule>();
    }

}
