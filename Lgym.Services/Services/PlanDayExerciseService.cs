using Lgym.Services.DTOs;
using Lgym.Services.DTOs.PlanDayExerciseService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;

namespace Lgym.Services.Services
{
    public class PlanDayExerciseService : IPlanDayExerciseService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public PlanDayExerciseService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }

        public async Task<IdDto> CreateAsync(RegisterPlanDayExerciseDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdDto> DeletedAsync(IdDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PlanDayExerciseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PlanDayExerciseDto> GetAsync(IdDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdDto> UpdateAsync(PlanDayExerciseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
