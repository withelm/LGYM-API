using Lgym.Services.DTOs;
using Lgym.Services.DTOs.PlanDayService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;

namespace Lgym.Services.Services
{
    public class PlanDayService : IPlanDayService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public PlanDayService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }

        public async Task<IdDto> CreateAsync(RegisterPlanDayDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdDto> DeletedAsync(IdDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PlanDayDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PlanDayDto> GetAsync(IdDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdDto> UpdateAsync(PlanDayDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
