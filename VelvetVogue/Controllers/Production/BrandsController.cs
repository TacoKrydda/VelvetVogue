using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var result = await _service.GetBrandsAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostBrand")]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            await _service.CreateBrandAsync(brand);
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            var result = await _service.GetBrandByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand(int id)
        {
            var result = await _service.DeleteBrand(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> UpdateBrand(int id, Brand brand)
        {
            var result = await _service.UpdateBrandAsync(id, brand);
            return Ok(result);
        }
    }
}
