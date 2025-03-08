using Lgym.Services.DTOs;
using Lgym.Services.DTOs.GymService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GymController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IGymService _gymService;

        public GymController(AppDbContext context, IGymService gymService)
        {
            _context = context;
            _gymService = gymService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegisterGymDto dto)
        {
            try
            {
                var result = await _gymService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] IdDto dto)
        {
            try
            {
                var result = await _gymService.GetAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] GymDto dto)
        {
            try
            {
                var result = await _gymService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleted")]
        public async Task<IActionResult> Deleted([FromBody] IdDto dto)
        {
            try
            {
                var result = await _gymService.DeletedAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _gymService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
