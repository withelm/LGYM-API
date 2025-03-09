using Lgym.Services.DTOs.PlanDayService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlanDayController : BaseController<PlanDayDto, RegisterPlanDayDto>
    {
        private readonly AppDbContext _context;
        private readonly IPlanDayService _planDayService;

        public PlanDayController(AppDbContext context, IPlanDayService planDayService) : base(planDayService)
        {
            _context = context;
            _planDayService = planDayService;
        }




    }
}
