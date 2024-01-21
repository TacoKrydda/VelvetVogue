using WebbShopClassLibrary.DTO;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Interfaces.Sales
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> PostOrderAsync(OrderModel model);
    }
}