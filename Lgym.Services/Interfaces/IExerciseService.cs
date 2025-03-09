using Lgym.Services.DTOs;
using Lgym.Services.DTOs.ExerciseService;

namespace Lgym.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<ExerciseDto> GetAsync(IdDto dto);
        Task<IList<ExerciseDto>> GetAllAsync();
        Task<IdDto> CreateAsync(RegisterExerciseDto dto);
        Task<IdDto> UpdateAsync(ExerciseDto dto);
        Task<IdDto> DeletedAsync(IdDto dto);
    }
}
