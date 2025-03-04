using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GymsController : Controller
    {
        private readonly AppDbContext _context;

        public GymsController(AppDbContext context)
        {
            _context = context;
        }






    }
}
