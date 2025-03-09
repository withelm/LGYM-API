using Lgym.Services.DTOs;
using Lgym.Services.DTOs.PlanService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Lgym.Services.Services
{
    public class PlanService : IPlanService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public PlanService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }

        public async Task<IdDto> CreateAsync(RegisterPlanDto dto)
        {
            var entity = new Plan(dto.Name, _currentUserService.CurrentUser);
            await _dbContext.Plans.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);

        }

        public async Task<IdDto> DeletedAsync(IdDto dto)
        {
            var query = _dbContext.Plans.Where(g => g.Id == dto.Id);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var entity = await query.SingleAsync();
            entity.SetDeleted();
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }

        public async Task<IList<PlanDto>> GetAllAsync()
        {
            IQueryable<Plan> query = _dbContext.Plans.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            return await query.Select(g => new PlanDto
            {
                Id = g.Id,
                Name = g.Name,
                Order = g.Order,
                Owner = new IdDto(g.Owner.Id)
            }).ToListAsync();
        }

        public async Task<PlanDto> GetAsync(IdDto dto)
        {
            IQueryable<Plan> query = _dbContext.Plans.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var result = await query.SingleAsync(g => g.Id == dto.Id);

            return new PlanDto
            {
                Id = result.Id,
                Name = result.Name,
                Order = result.Order,
                Owner = new IdDto(result.Owner.Id)
            };
        }

        public async Task<IdDto> UpdateAsync(PlanDto dto)
        {
            var query = _dbContext.Plans.Where(g => g.Id == dto.Id);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }

            var entity = await query.SingleAsync();
            entity.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }
    }
}
