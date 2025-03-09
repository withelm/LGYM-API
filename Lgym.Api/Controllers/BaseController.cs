using Lgym.Services.DTOs;
using Lgym.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    public class BaseController<T, K> : Controller where T : class where K : class
    {

        private readonly IBaseService<T, K> _baseService;
        public BaseController(IBaseService<T, K> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] K dto)
        {
            try
            {
                var result = await _baseService.CreateAsync(dto);
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
                var result = await _baseService.GetAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] T dto)
        {
            try
            {
                var result = await _baseService.UpdateAsync(dto);
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
                var result = await _baseService.DeletedAsync(dto);
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
                var result = await _baseService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
