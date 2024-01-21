using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _service.GetProductAsync();
            return Ok(result);
        }
        [HttpPost(Name = "PostProduct")]
        public async Task<ActionResult<Product>> PostProduction(Product product)
        {
            var result = await _service.CreateProductAsync(product);
            return Ok(result);
        }
    }
}
