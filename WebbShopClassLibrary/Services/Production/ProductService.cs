using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        public async Task<Product> CreateAsync(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Add(entity);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (DbUpdateException ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApplicationException("Could not create entity.", ex);

                }
            }

            return entity;
        }


        public async Task<Product> DeleteAsync(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} was not found");
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Products.Remove(result);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _context.Products
                                    .Include(p => p.Brand)
                                    .Include(p => p.Category)
                                    .Include(p => p.Color)
                                    .Include(p => p.Size)
                                    .Include(p => p.Stock)
                                    .ToListAsync();
            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var result = await _context.Products
                                    .Include(p => p.Brand)
                                    .Include(p => p.Category)
                                    .Include(p => p.Color)
                                    .Include(p => p.Size)
                                    .Include(p => p.Stock)
                                    .SingleOrDefaultAsync(p => p.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} was not found");
            }
            
            return result;
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }

            var existingEntity = await _context.Products.FindAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} was not found");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return existingEntity;
        }

    }
}
