namespace ClincProject.Data.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }


        public ICollection<EmployeeSchedules>? EmployeeSchedules { get; set; } = new HashSet<EmployeeSchedules>();
        public ICollection<Appointment>? Appointments { get; set; } = new HashSet<Appointment>();
    }
}
