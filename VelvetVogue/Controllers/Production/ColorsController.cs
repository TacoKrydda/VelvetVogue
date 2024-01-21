using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetColors")]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
            var result = await _service.GetColorsAsync();
            return Ok(result);
        }
        [HttpPost(Name = "PostColor")]
        public async Task<ActionResult<Color>> PostColors(Color color)
        {
            var result = await _service.CreateColorsAsync(color);
            return Ok(result);
        }
    }
}
