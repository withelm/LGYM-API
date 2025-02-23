using Lgym.Services.Interfaces;

namespace Lgym.Services.DTOs.UserService
{
    public class RegisterUserDto : IUserDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
