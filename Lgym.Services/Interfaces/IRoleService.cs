using Lgym.Services.Models;

namespace Lgym.Services.Interfaces
{
    public interface IRoleService
    {
        string AdminRoleName { get; }
        string UserRoleName { get; }
        string[] AdminClaims { get; }
        string[] UserClaims { get; }
        string[] GetClaims(User user);
    }
}
