using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class StockService : IGenericService<Stock>
    {
        private readonly IGenericService<Stock> _genericService;

        public StockService(GenericService<Stock> genericService)
        {
            _genericService = genericService;
        }
        public Task<Stock> CreateAsync(Stock entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Stock> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Stock>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Stock> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Stock> UpdateAsync(int id, Stock entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
