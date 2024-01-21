using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.DTO;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace VelvetVogue.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var result = await _service.GetOrdersAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostOrder")]
        public async Task<ActionResult<Order>> PostOrder(OrderModel model)
        {
            var result = await _service.PostOrderAsync(model);
            return Ok(result);
        }
    }
}
