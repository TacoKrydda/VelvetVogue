using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IGenericService<Color> _service;

        public ColorsController(IGenericService<Color> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostColor")]
        public async Task<ActionResult<Color>> CreateAsync(Color entity)
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
        public async Task<ActionResult<Color>> DeleteAsync(int id)
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

        [HttpGet(Name = "GetColors")]
        public async Task<ActionResult<IEnumerable<Color>>> GetAllAsync()
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
        public async Task<ActionResult<Color>> GetByIdAsync(int id)
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
        public async Task<ActionResult<Color>> UpdateAsync(int id, Color entity)
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
