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
            if (_context.Brands == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
    }
}
