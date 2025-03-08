using Lgym.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Lgym.Services.Services
{
    public class BaseCurrentUserService : IBaseCurrentUserService
    {

        public BaseCurrentUserService(IHttpContextAccessor accessor)
        {

            var userClaims = accessor.HttpContext?.User;
            if (userClaims?.Identity is not { IsAuthenticated: true })
            {
                return;
            }

            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }
            if (int.TryParse(userId, out var currentUserId))
            {
                _userId = currentUserId;
            }

        }

        private readonly int? _userId;

        public int? UserId => _userId;
    }
}
