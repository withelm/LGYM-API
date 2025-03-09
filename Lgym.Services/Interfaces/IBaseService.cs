using Lgym.Services.DTOs;

namespace Lgym.Services.Interfaces
{
    public interface IBaseService<T, K> where T : class where K : class
    {
        Task<T> GetAsync(IdDto dto);
        Task<IList<T>> GetAllAsync();
        Task<IdDto> CreateAsync(K dto);
        Task<IdDto> UpdateAsync(T dto);
        Task<IdDto> DeletedAsync(IdDto dto);
    }
}
