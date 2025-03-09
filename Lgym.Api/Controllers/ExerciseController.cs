using Lgym.Services.DTOs;
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
    public class ExerciseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IExerciseService _exerciseService;

        public ExerciseController(AppDbContext context, IExerciseService exerciseService)
        {
            _context = context;
            _exerciseService = exerciseService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegisterExerciseDto dto)
        {
            try
            {
                var result = await _exerciseService.CreateAsync(dto);
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
                var result = await _exerciseService.GetAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ExerciseDto dto)
        {
            try
            {
                var result = await _exerciseService.UpdateAsync(dto);
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
                var result = await _exerciseService.DeletedAsync(dto);
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
                var result = await _exerciseService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
