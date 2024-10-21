namespace ClincProject.Data.Helpers
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issure { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public bool ValidateIssure { get; set; }
        public bool validateAudience { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateIssureSigningKey { get; set; }
        public int AccessTokenExpireDate { get; set; }
        public int RefreshTokenExpireDate { get; set; }
    }
}
