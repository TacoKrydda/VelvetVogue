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
            var result = await _service.CreateAsync(size);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Size>> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet(Name = "GetSizes")]
        public async Task<ActionResult<IEnumerable<Size>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Size>> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Size>> UpdateAsync(int id, Size size)
        {
            var result = await _service.UpdateAsync(id, size);
            return Ok(result);
        }
    }
}
