using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class ProductService : IGenericService<Product>
    {
        private readonly IGenericService<Product> _genericService;

        public ProductService(GenericService<Product> genericService)
        {
            _genericService = genericService;
        }
        public Task<Product> CreateAsync(Product entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Product> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Product> UpdateAsync(int id, Product entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
