using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Models.Sales;
using WebbShopClassLibrary.Utilities;

namespace VelvetVogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementUtilitiesController : ControllerBase
    {
        private readonly IManagementUtilities _utilities;

        public ManagementUtilitiesController(IManagementUtilities utilities)
        {
            _utilities = utilities;
        }
        [HttpGet]
        public async Task<ActionResult<Staff>> GetStaffByOrderId(int id)
        {
            var staff = await _utilities.GetStaffIdsForOrder(id);
            return Ok(staff);
        }
    }
}
