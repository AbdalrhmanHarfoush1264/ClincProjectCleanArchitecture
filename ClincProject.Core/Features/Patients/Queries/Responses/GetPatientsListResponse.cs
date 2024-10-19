namespace ClincProject.Core.Features.Patients.Queries.Responses
{
    public class GetPatientsListResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string? Phone { get; set; }
        //public bool Gender { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
