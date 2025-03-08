using Lgym.Services.Interfaces;
using Lgym.Services.Models;

namespace Lgym.Services.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly bool _isAuthenticated;

        private readonly User _currentUser;
        private readonly IRoleService _roleService;

        public CurrentUserService(IBaseCurrentUserService baseCurrentUserService, AppDbContext db, IRoleService roleService)
        {
            if (baseCurrentUserService.UserId is null)
            {
                _isAuthenticated = false;
                return;
            }
            _isAuthenticated = true;
            _roleService = roleService;
            _currentUser = db.Users.First(x => x.Id == baseCurrentUserService.UserId.Value);
        }

        public bool IsAuthenticated => _isAuthenticated;
        public bool IsAdmin => _currentUser.Role == _roleService.AdminRoleName;
        public User CurrentUser => _currentUser;

    }
}
