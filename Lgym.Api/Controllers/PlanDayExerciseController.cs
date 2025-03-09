using Lgym.Services.DTOs.PlanDayExerciseService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlanDayExerciseController : BaseController<PlanDayExerciseDto, RegisterPlanDayExerciseDto>
    {
        private readonly AppDbContext _context;
        private readonly IPlanDayExerciseService _planDayExerciseService;

        public PlanDayExerciseController(AppDbContext context, IPlanDayExerciseService planDayExerciseService) : base(planDayExerciseService)
        {
            _context = context;
            _planDayExerciseService = planDayExerciseService;
        }




    }
}
