namespace Notes.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string Scopes { get; set; }
    }
}