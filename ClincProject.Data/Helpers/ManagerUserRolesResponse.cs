namespace ClincProject.Data.Helpers
{
    public class ManagerUserRolesResponse
    {
        public int UserId { get; set; }
        public List<UserRoles> UserRoles { get; set; }
    }

    public class UserRoles
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool HasRole { get; set; }
    }
}
