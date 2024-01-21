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
    public class ProductService : IProductService
    {
        private readonly WebbShopContext _context;

        public ProductService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            if (_context.Products == null)
            {
                return Enumerable.Empty<Product>();
            }
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
