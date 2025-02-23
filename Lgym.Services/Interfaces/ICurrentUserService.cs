using Lgym.Services.Models;

namespace Lgym.Services.Interfaces
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        User CurrentUser { get; }
    }
}
