using Lgym.Services.DTOs.PlanService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlanController : BaseController<PlanDto, RegisterPlanDto>
    {
        private readonly AppDbContext _context;
        private readonly IPlanService _planService;

        public PlanController(AppDbContext context, IPlanService planService) : base(planService)
        {
            _context = context;
            _planService = planService;
        }




    }
}
