using Lgym.Services.Interfaces;

namespace Lgym.Services.DTOs.UserService
{
    public class LoginUserDto : IUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
