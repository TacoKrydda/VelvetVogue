using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

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
        public async Task<ActionResult<Size>> CreateAsync(Size entity)
        {
            try
            {
                var result = await _service.CreateAsync(entity);
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
        public async Task<ActionResult<Size>> UpdateAsync(int id, Size entity)
        {
            try
            {
                var result = await _service.UpdateAsync(id, entity);
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
