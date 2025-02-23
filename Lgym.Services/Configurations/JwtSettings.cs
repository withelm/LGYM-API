namespace Lgym.Services.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpiresInMinutes { get; set; }
    }

}
