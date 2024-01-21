using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace VelvetVogue.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var result = await _service.GetCustomersAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostCustomer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var result = await _service.CreateCustomerAsync(customer);
            return Ok(result);
        }
    }
}
