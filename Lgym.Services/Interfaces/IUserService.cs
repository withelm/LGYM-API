using Lgym.Services.DTOs.UserService;
using Lgym.Services.Models;

namespace Lgym.Services.Interfaces
{
    public interface IUserService
    {
        User Register(RegisterUserDto dto);
        LoggedUserDto Login(LoginUserDto dto);
    }
}
