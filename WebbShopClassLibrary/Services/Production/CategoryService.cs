using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class CategoryService : ICategoryService
    {
        private readonly WebbShopContext _context;

        public CategoryService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> FindCategoryByIdAsync(int id)
        {
            var existingObject = await _context.Categories.SingleOrDefaultAsync(x=>x.CategoryId == id);
            if (existingObject == null)
            {
                throw new KeyNotFoundException($"Object with ID {id} was not found");
            }
            _context.Entry(existingObject).State = EntityState.Detached;
            return existingObject;
        }

        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            if (_context.Categories == null)
            {
                return Enumerable.Empty<Category>();
            }
            return await _context.Categories.ToListAsync();
        }
        
    }
}
