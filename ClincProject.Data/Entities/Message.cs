namespace ClincProject.Data.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
