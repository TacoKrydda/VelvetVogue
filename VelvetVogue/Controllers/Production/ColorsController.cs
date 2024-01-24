using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Services;

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
        public async Task<ActionResult<Color>> CreateAsync(Color color)
        {
            var result = await _service.CreateAsync(color);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet(Name = "GetColors")]
        public async Task<ActionResult<IEnumerable<Color>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Color>> UpdateAsync(int id, Color color)
        {
            var result = await _service.UpdateAsync(id, color);
            return Ok(result);
        }
    }
}
