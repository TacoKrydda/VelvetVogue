using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Services;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IGenericService<Stock> _service;

        public StocksController(IGenericService<Stock> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostStock")]
        public async Task<ActionResult<Stock>> CreateAsync(Stock entity)
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
        public async Task<ActionResult<Stock>> DeleteAsync(int id)
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

        [HttpGet(Name = "GetStocks")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllAsync()
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
        public async Task<ActionResult<Stock>> GetByIdAsync(int id)
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
        public async Task<ActionResult<Stock>> UpdateAsync(int id, Stock entity)
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
