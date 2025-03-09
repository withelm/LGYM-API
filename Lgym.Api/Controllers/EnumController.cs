using Lgym.Services.DTOs.EnumService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EnumController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEnumService _enumService;

        public EnumController(AppDbContext context, IEnumService enumService)
        {
            _context = context;
            _enumService = enumService;
        }


        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] EnumQueryDto dto)
        {
            try
            {
                var result = await _enumService.Get(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
