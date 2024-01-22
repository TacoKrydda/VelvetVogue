using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.DTO;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class OrderService : IOrderService
    {
        private readonly WebbShopContext _context;

        public OrderService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            if (_context == null)
            {
                return Enumerable.Empty<Order>();
            }
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> PostOrderAsync(OrderModel model)
        {
            var newOrder = new Order
            {
                CartItems = model.CartItems,
                CustomerId = model.CustomerId,
                OrderDate = model.OrderDate,
                OrderStatus = model.OrderStatus,
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            var cartItemsCopy = newOrder.CartItems.ToList();

            foreach (var item in cartItemsCopy)
            {
                item.OrderId = newOrder.OrderId;
                newOrder.CartItems.Add(item);
            }
            //_context.CartItems.AddRange(newOrder.CartItems);
            await _context.SaveChangesAsync();
            return newOrder;

        }
    }
}
