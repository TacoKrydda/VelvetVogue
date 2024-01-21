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
    public class SizeService : ISizeService
    {
        private readonly WebbShopContext _context;

        public SizeService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
            if (_context.Sizes == null)
            {
                return Enumerable.Empty<Size>();
            }
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> CreateSizeAsync(Size size)
        {
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            _context.Sizes.Add(size);
            await _context.SaveChangesAsync();
            return size;
        }

    }
}
