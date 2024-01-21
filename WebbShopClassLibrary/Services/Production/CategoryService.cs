using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            if (_context.Categories == null)
            {
                return Enumerable.Empty<Category>();
            }
            return await _context.Categories.ToListAsync();
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
    }
}
