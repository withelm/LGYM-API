using Lgym.Services.DTOs.UserService;
using Lgym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                var user = _userService.Register(dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto dto)
        {
            try
            {
                var user = _userService.Login(dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
