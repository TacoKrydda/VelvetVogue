using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class CartItemService : IGenericService<CartItem>
    {
        private readonly IGenericService<CartItem> _genericService;

        public CartItemService(GenericService<CartItem> genericService)
        {
            _genericService = genericService;
        }
        public Task<CartItem> CreateAsync(CartItem entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<CartItem> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<CartItem> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<CartItem> UpdateAsync(int id, CartItem entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
