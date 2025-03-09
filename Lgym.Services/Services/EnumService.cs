using Lgym.Resources.Extensions;
using Lgym.Services.DTOs;
using Lgym.Services.DTOs.EnumService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;

namespace Lgym.Services.Services
{
    public class EnumService : IEnumService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public EnumService(AppDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

        }

        public async Task<IEnumerable<LookupItemDto>> Get(EnumQueryDto dto)
        {
            var assembly = typeof(EnumService).Assembly;

            var enumType = assembly.GetTypes().Where(x => x.Name == dto.Type && x.IsEnum).Single();

            var values = Enum.GetValues(enumType).Cast<Enum>();
            var result = values.Select(x => new LookupItemDto(x.ToString(), x.GetDescription()));
            result = result.OrderBy(x => x.Name);
            return result.AsEnumerable();
        }
    }
}
