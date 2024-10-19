namespace ClincProject.Data.Entities
{
    public class ClinicDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        public ICollection<EmployeeSchedules>? EmployeeSchedules { get; set; } = new HashSet<EmployeeSchedules>();
    }
}
