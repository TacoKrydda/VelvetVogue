using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;

namespace VelvetVogue.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStaffAssignmentsController : ControllerBase
    {
        private readonly IGenericService<OrderStaffAssignment> _service;

        public OrderStaffAssignmentsController(IGenericService<OrderStaffAssignment> service)
        {
            _service = service;
        }

        [HttpPost(Name = "PostOrderStaffAssignment")]
        public async Task<ActionResult<OrderStaffAssignment>> CreateAsync(OrderStaffAssignment entity)
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
        public async Task<ActionResult<OrderStaffAssignment>> DeleteAsync(int id)
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

        [HttpGet(Name = "GetOrderStaffAssignments")]
        public async Task<ActionResult<IEnumerable<OrderStaffAssignment>>> GetAllAsync()
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
        public async Task<ActionResult<OrderStaffAssignment>> GetByIdAsync(int id)
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
        public async Task<ActionResult<OrderStaffAssignment>> UpdateAsync(int id, OrderStaffAssignment entity)
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
