using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;

namespace VelvetVogue.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly IGenericService<CartItem> _service;

        public CartItemsController(IGenericService<CartItem> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostCartItem")]
        public async Task<ActionResult<CartItem>> CreateAsync(CartItem entity)
        {
            try
            {
                var result = await _service.CreateAsync(entity);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItem>> DeleteAsync(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet(Name = "GetCartItems")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetAllAsync()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartItem>> UpdateAsync(int id, CartItem entity)
        {
            try
            {
                var result = await _service.UpdateAsync(id, entity);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
