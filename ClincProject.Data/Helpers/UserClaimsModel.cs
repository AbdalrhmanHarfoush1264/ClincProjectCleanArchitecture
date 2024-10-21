namespace ClincProject.Data.Helpers
{
    public class UserClaimsModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
    }
}
