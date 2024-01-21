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
    }
}
