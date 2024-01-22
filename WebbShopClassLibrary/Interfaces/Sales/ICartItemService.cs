using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Interfaces.Sales
{
    public interface ICartItemService
    {
        Task<CartItem> CreateCartItemAsync(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem> UpdateCartItemAsync(CartItem cartItem);
    }
}