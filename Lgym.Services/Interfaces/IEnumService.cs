using Lgym.Services.DTOs;
using Lgym.Services.DTOs.EnumService;

namespace Lgym.Services.Interfaces
{
    public interface IEnumService
    {
        Task<IEnumerable<LookupItemDto>> Get(EnumQueryDto dto);
    }
}
