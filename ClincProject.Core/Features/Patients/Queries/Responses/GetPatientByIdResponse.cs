namespace ClincProject.Core.Features.Patients.Queries.Responses
{
    public class GetPatientByIdResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
