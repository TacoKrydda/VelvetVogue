using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class BrandService : IBrandService
    {
        private readonly WebbShopContext _context;

        public BrandService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            if (_context.Brands == null)
            {
                return Enumerable.Empty<Brand>();
            }
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            var result = await FindBrandByIdAsync(id);
            return result;
        }

        public async Task<Brand> UpdateBrandAsync(int id, Brand brand)
        {
            var result = await FindBrandByIdAsync(id);
            if (result.BrandId != brand.BrandId)
            {
                throw new KeyNotFoundException($"ID's not matching {id} != {brand.BrandId}");
            }
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> DeleteBrand(int id)
        {
            var result = await FindBrandByIdAsync(id);
            _context.Brands.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Brand> FindBrandByIdAsync(int id)
        {
            var existingProduct = await _context.Brands.SingleOrDefaultAsync(x => x.BrandId == id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Brand with ID {id} was not found");
            }
            _context.Entry(existingProduct).State = EntityState.Detached;
            return existingProduct;
        }

        //private void DetachEntity<T>(T entity) where T : class
        //{
        //    _context.Entry(entity).State = EntityState.Detached;
        //}
    }
}
