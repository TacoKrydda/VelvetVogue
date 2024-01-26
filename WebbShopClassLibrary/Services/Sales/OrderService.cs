using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.DTO;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class OrderService : IGenericService<Order>
    {
        private readonly IGenericService<Order> _genericService;

        public OrderService(IGenericService<Order> genericService)
        {
            _genericService = genericService;
        }
        public Task<Order> CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Order> UpdateAsync(int id, Order entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }

        //public async Task<Order> PostOrderAsync(OrderModel model)
        //{
        //    var newOrder = new Order
        //    {
        //        CartItems = model.CartItems,
        //        CustomerId = model.CustomerId,
        //        OrderDate = model.OrderDate,
        //        OrderStatus = model.OrderStatus,
        //    };
        //    _context.Orders.Add(newOrder);
        //    await _context.SaveChangesAsync();

        //    var cartItemsCopy = newOrder.CartItems.ToList();

        //    foreach (var item in cartItemsCopy)
        //    {
        //        item.OrderId = newOrder.Id;
        //        newOrder.CartItems.Add(item);
        //    }
        //    await _context.SaveChangesAsync();
        //    return newOrder;
        //}
    }
}
