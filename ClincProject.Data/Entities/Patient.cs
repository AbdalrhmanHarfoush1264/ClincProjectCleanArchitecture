namespace ClincProject.Data.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<PatientCase>? PatientCases { get; set; } = new HashSet<PatientCase>();
    }
}
