using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class CartItemService : ICartItemService
    {
        private readonly WebbShopContext _context;

        public CartItemService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            if (_context.CartItems == null)
            {
                return Enumerable.Empty<CartItem>();
            }
            return await _context.CartItems.ToListAsync();
        }

        public async Task<CartItem> CreateCartItemAsync(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new ArgumentNullException(nameof(cartItem));
            }
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> UpdateCartItemAsync(CartItem cartItem)
        {
            if (cartItem == null)
            {
                throw new KeyNotFoundException($"CartItem with ID {cartItem} not found");
            }
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }
    }
}
