using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class ProductService : IGenericService<Product>
    {
        private readonly IGenericService<Product> _genericService;
        private readonly GenericService<Stock> _stockService;

        public ProductService(GenericService<Product> genericService, GenericService<Stock> stockService)
        {
            _genericService = genericService;
            _stockService = stockService;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            var productResult = await _genericService.CreateAsync(entity);
            return productResult;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            return  await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
