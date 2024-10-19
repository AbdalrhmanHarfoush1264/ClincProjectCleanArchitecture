namespace ClincProject.Core.Features.Clinics.Queries.Response
{
    public class GetClinicListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Details { get; set; }
    }
}
