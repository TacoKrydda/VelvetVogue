using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class ColorService : IColorService
    {
        private readonly WebbShopContext _context;

        public ColorService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            if (_context.Colors == null)
            {
                return Enumerable.Empty<Color>();
            }
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> CreateColorsAsync(Color color)
        {
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();
            return color;
        }

    }
}
