using Lgym.Resources.Extensions;
using Lgym.Services.DTOs;
using Lgym.Services.DTOs.ExerciseService;
using Lgym.Services.Enums;
using Lgym.Services.Extensions;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Lgym.Services.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public ExerciseService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }

        public async Task<IdDto> CreateAsync(RegisterExerciseDto dto)
        {
            var bodyPart = dto.BodyPart.Id.ParseEnum<BodyPart>();
            var entity = new Exercise(dto.Name, _currentUserService.CurrentUser, bodyPart);

            if (_currentUserService.IsAdmin)
            {
                entity.IsGlobal = dto.IsGlobal;
            }

            await _dbContext.Exercises.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }

        public async Task<IdDto> DeletedAsync(IdDto dto)
        {
            var query = _dbContext.Exercises.Where(g => g.Id == dto.Id);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var entity = await query.SingleAsync();
            entity.SetDeleted();
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }

        public async Task<IList<ExerciseDto>> GetAllAsync()
        {
            IQueryable<Exercise> query = _dbContext.Exercises.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser || g.IsGlobal);
            }
            return await query.Select(g => new ExerciseDto
            {
                Id = g.Id,
                Name = g.DisplayName,
                Owner = new IdDto(g.Owner.Id),
                BodyPart = new LookupItemDto(g.BodyPart.ToString(), g.BodyPart.GetDescription()),
                IsGlobal = g.IsGlobal
            }).ToListAsync();
        }

        public async Task<ExerciseDto> GetAsync(IdDto dto)
        {
            IQueryable<Exercise> query = _dbContext.Exercises.Include(g => g.Owner);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }
            var result = await query.SingleAsync(g => g.Id == dto.Id);

            return new ExerciseDto
            {
                Id = result.Id,
                Name = result.DisplayName,
                Owner = new IdDto(result.Owner.Id),
                BodyPart = new LookupItemDto(result.BodyPart.ToString(), result.BodyPart.GetDescription()),
                IsGlobal = result.IsGlobal
            };
        }

        public async Task<IdDto> UpdateAsync(ExerciseDto dto)
        {
            var query = _dbContext.Exercises.Where(g => g.Id == dto.Id);
            if (!_currentUserService.IsAdmin)
            {
                query = query.Where(g => g.Owner == _currentUserService.CurrentUser);
            }

            var entity = await query.SingleAsync();
            entity.Name = dto.Name;
            entity.BodyPart = dto.BodyPart.Id.ParseEnum<BodyPart>();
            if (_currentUserService.IsAdmin)
            {
                entity.IsGlobal = dto.IsGlobal;

                var isExistTranslation = Resources.Resources.Exercise.ResourceManager.GetString(dto.Name);
                if (string.IsNullOrEmpty(isExistTranslation))
                {
                    throw new ArgumentOutOfRangeException(nameof(dto.Name));
                }
            }
            await _dbContext.SaveChangesAsync();
            return new IdDto(entity.Id);
        }
    }
}
