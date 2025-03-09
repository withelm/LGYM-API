using Lgym.Services.DTOs.ExerciseService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : BaseController<ExerciseDto, RegisterExerciseDto>
    {
        private readonly AppDbContext _context;
        private readonly IExerciseService _exerciseService;

        public ExerciseController(AppDbContext context, IExerciseService exerciseService) : base(exerciseService)
        {
            _context = context;
            _exerciseService = exerciseService;
        }


    }
}
