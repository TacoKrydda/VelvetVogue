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
        public async Task<CartItem> CreateAsync(CartItem entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<CartItem> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<CartItem> UpdateAsync(int id, CartItem entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
