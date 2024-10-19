namespace ClincProject.Core.Features.Patients.Queries.Responses
{
    public class GetPatientsPaginatedListResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public GetPatientsPaginatedListResponse(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        //public string? Phone { get; set; }
        //public bool Gender { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
