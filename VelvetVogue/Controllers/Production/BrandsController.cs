using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericService<Brand> _service;

        public BrandsController(IGenericService<Brand> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostBrand")]
        public async Task<ActionResult<Brand>> CreateAsync(Brand entity)
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
        public async Task<ActionResult<Brand>> DeleteAsync(int id)
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

        [HttpGet(Name = "GetBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllAsync()
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
        public async Task<ActionResult<Brand>> GetByIdAsync(int id)
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
        public async Task<ActionResult<Brand>> UpdateAsync(int id, Brand entity)
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
