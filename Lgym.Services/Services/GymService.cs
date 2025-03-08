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

        public async Task<IdDto> CreateAsync(RegisterGymDto dto)
        {
            var entity = new Gym(dto.Name, _currentUserService.CurrentUser);
            await _dbContext.Gyms.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }

        public async Task<IdDto> DeletedAsync(IdDto dto)
        {
            var entity = await _dbContext.Gyms.SingleAsync(g => g.Id == dto.Id);
            entity.SetDeleted();
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }

        public async Task<IList<GymDto>> GetAllAsync()
        {
            IQueryable<Gym> query = _dbContext.Gyms.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            return await query.Select(g => new GymDto
            {
                Id = g.Id,
                Name = g.Name,
                Owner = new IdDto(g.Owner.Id)
            }).ToListAsync();
        }

        public async Task<GymDto> GetAsync(IdDto dto)
        {
            IQueryable<Gym> query = _dbContext.Gyms.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var result = await query.SingleAsync(g => g.Id == dto.Id);

            return new GymDto
            {
                Id = result.Id,
                Name = result.Name,
                Owner = new IdDto(result.Owner.Id)
            };
        }

        public async Task<IdDto> UpdateAsync(GymDto dto)
        {
            var entity = await _dbContext.Gyms.SingleAsync(g => g.Id == dto.Id);
            entity.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }
    }
}
