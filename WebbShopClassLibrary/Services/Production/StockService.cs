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
    public class StockService : IStockService
    {
        private readonly WebbShopContext _context;

        public StockService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            if (_context.Stocks == null)
            {
                return Enumerable.Empty<Stock>();
            }
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

    }
}
