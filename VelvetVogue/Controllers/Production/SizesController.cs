using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _service;

        public SizesController(ISizeService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetSizes")]
        public async Task<ActionResult<IEnumerable<Size>>> GetSizes()
        {
            var result = await _service.GetSizesAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostSize")]
        public async Task<ActionResult<Size>> PostSizes(Size size)
        {
            var result = await _service.CreateSizeAsync(size);
            return Ok(result);
        }
    }
}
