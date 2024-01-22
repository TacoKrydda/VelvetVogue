using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace VelvetVogue.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService _service;

        public CartItemsController(ICartItemService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCartItems")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            var result = await _service.GetCartItemsAsync();
            return Ok(result);
        }
        [HttpPost(Name = "PostCartItem")]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            var result = await _service.UpdateCartItemAsync(cartItem);
            return Ok(result);
        }
        [HttpPut(Name = "PutCartItem")]
        public async Task<ActionResult<CartItem>> PutCartItem(CartItem cartItem)
        {
            var result = await _service.UpdateCartItemAsync(cartItem);
            return Ok(result);
        }
    }
}
