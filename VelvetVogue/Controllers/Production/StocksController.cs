using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _service;

        public StocksController(IStockService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetStocks")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            var result = await _service.GetStocksAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostStock")]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            var result = await _service.CreateStockAsync(stock);
            return Ok(result);
        }
    }
}
