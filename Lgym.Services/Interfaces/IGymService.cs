using Lgym.Services.DTOs;
using Lgym.Services.DTOs.GymService;

namespace Lgym.Services.Interfaces
{
    public interface IGymService
    {
        Task<GymDto> GetAsync(IdDto dto);
        Task<IList<GymDto>> GetAllAsync();
        Task<IdDto> CreateAsync(RegisterGymDto dto);
        Task UpdateAsync(GymDto dto);
        Task DeleteAsync(IdDto dto);
    }
}
