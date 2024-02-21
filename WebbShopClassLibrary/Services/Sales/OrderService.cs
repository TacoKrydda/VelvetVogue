using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;
using WebbShopClassLibrary.Utilities;

namespace WebbShopClassLibrary.Services.Sales
{
    public class OrderService : IGenericService<Order>
    {
        private readonly IGenericService<Order> _genericService;

        public OrderService(GenericService<Order> genericService)
        {
            _genericService = genericService;
        }
        public async Task<Order> CreateAsync(Order entity)
        {
            var cartItemsCopy = entity.CartItems.ToList();

            var test = new testOrder();

            var orderResult = await _genericService.CreateAsync(entity);

            // This may work but i need to send product with cartitem.
            // Right now product is null
            orderResult.TotalPrice = test.CartItems.Sum(x=>x.Product.Price * x.Quantity);
            await _genericService.UpdateAsync(orderResult.Id, orderResult);

            return orderResult;
        }

        public Task<Order> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Order>> GetAllAsync(params string[] includeProperties)
        {
            return _genericService.GetAllAsync("CartItems");
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
    }
}
