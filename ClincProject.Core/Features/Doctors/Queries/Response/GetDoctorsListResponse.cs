namespace ClincProject.Core.Features.Doctors.Queries.Response
{
    public class GetDoctorsListResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
