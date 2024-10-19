namespace ClincProject.Core.Features.Users.Queries.Responses
{
    public class GetUserPaginatedListResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Country { get; set; }
        public string? Address { get; set; }

    }
}
