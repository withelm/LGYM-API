using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Lgym.Services.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly bool _isAuthenticated;

        private readonly User _currentUser;
        private readonly IRoleService _roleService;

        public CurrentUserService(IHttpContextAccessor accessor, AppDbContext db, IRoleService roleService)
        {
            _roleService = roleService;
            var userClaims = accessor.HttpContext?.User;
            if (userClaims?.Identity is not { IsAuthenticated: true })
            {
                _isAuthenticated = false;
                return;
            }

            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                _isAuthenticated = false;
                return;
            }
            _currentUser = db.Users.FirstOrDefault(x => x.Id == int.Parse(userId));
            if (_currentUser is null)
            {

                _isAuthenticated = false;
                return;
            }
            _isAuthenticated = true;
        }

        public bool IsAuthenticated => _isAuthenticated;
        public bool IsAdmin => _currentUser.Role == _roleService.AdminRoleName;
        public User CurrentUser => _currentUser;

    }
}
