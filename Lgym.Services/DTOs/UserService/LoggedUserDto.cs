namespace Lgym.Services.DTOs.UserService
{
    public class LoggedUserDto
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string[] Claims { get; set; }
    }
}
