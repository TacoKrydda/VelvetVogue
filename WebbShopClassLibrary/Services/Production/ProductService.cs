using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> UpdateProductAsync(Product product)
        {
            //var existingProduct = await _context.Products.FindAsync(product.ProductId);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.ProductId} not found");
            }
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
