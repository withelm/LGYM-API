using Lgym.Services.Interfaces;
using Lgym.Services.Models;

namespace Lgym.Services.Services
{
    public class RoleService : IRoleService
    {
        public string AdminRoleName => "Admin";

        public string UserRoleName => "User";

        public string[] AdminClaims => new[] { "IsAdmin" };

        public string[] UserClaims => new[] { "IsUser" };

        public string[] GetClaims(User user)
        {
            switch (user.Role)
            {
                case "Admin":
                    return AdminClaims;
                case "User":
                    return UserClaims;
                default:
                    return new string[0];
            }
        }
    }

}
