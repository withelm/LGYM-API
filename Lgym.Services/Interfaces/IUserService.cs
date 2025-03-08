using Lgym.Services.DTOs;
using Lgym.Services.DTOs.UserService;

namespace Lgym.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdDto> Register(RegisterUserDto dto);
        Task<LoggedUserDto> Login(LoginUserDto dto);
    }
}
