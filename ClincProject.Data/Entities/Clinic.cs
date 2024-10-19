namespace ClincProject.Data.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Details { get; set; }

        public ICollection<ClinicDepartment>? ClinicDepartments { get; set; } = new HashSet<ClinicDepartment>();
    }
}
