using Lgym.Services.DTOs;
using Lgym.Services.DTOs.GymService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Lgym.Services.Services
{
    public class GymService : IGymService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public GymService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }
        public Task<IdDto> CreateAsync(RegisterGymDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GymDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GymDto> GetAsync(IdDto dto)
        {
            IQueryable<Gym> query = _dbContext.Gyms.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var result = await query.FirstOrDefaultAsync(g => g.Id == dto.Id);

            return new GymDto
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public Task UpdateAsync(GymDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
