using Microsoft.AspNetCore.Mvc;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace VelvetVogue.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var result = await _service.GetCategorysAsync();
            return Ok(result);
        }

        [HttpPost(Name = "PostCategory")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var result = await _service.CreateCategoryAsync(category);
            return Ok(result);
        }
    }
}
