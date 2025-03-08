using Lgym.Services.Configurations;
using Lgym.Services.DTOs;
using Lgym.Services.DTOs.UserService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Lgym.Services.Security;
using Microsoft.EntityFrameworkCore;

namespace Lgym.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly SecuritySettings _securitySettings;
        private readonly JwtSettings _jwtSettings;
        private readonly IRoleService _roleService;
        public UserService(AppDbContext appDbContext, SecuritySettings securitySettings, JwtSettings jwtSettings, IRoleService roleService)
        {
            _appDbContext = appDbContext;
            _securitySettings = securitySettings;
            _jwtSettings = jwtSettings;
            _roleService = roleService;
        }

        public async Task<LoggedUserDto> Login(LoginUserDto dto)
        {

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Login == dto.Login && x.Password == GetHashedPassword(dto));
            if (user == null)
            {
                throw new Exception("Niepoprawne dane logowania");
            }
            return new LoggedUserDto()
            {
                Token = JwtGenerator.Generate(user, _jwtSettings, _roleService.GetClaims(user)),
                Login = user.Login,
                Claims = _roleService.GetClaims(user)
            };

        }

        public async Task<IdDto> Register(RegisterUserDto dto)
        {
            var existingUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Login == dto.Login || x.Email == dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Użytkownik o podanym loginie lub emailu już istnieje");
            }
            var newUser = new User
            {
                Login = dto.Login,
                Email = dto.Email,
                Role = _roleService.UserRoleName,
                Password = GetHashedPassword(dto)
            };

            await _appDbContext.Users.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
            return new IdDto(newUser.Id);
        }


        private string GetHashedPassword(IUserDto dto)
        {
            return PasswordHasher.HashPassword(password: dto.Password, userName: dto.Login, globalSalt: _securitySettings.GlobalSalt);
        }
    }
}
