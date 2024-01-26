using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Services;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly IGenericService<Size> _service;

        public SizesController(IGenericService<Size> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostSize")]
        public async Task<ActionResult<Size>> CreateAsync(Size size)
        {
            try
            {
                var result = await _service.CreateAsync(size);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Size>> DeleteAsync(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet(Name = "GetSizes")]
        public async Task<ActionResult<IEnumerable<Size>>> GetAllAsync()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Size>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Size>> UpdateAsync(int id, Size size)
        {
            try
            {
                var result = await _service.UpdateAsync(id, size);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
