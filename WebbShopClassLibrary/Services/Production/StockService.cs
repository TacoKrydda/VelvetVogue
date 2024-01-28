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
        public async Task<Stock> CreateAsync(Stock entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Stock> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Stock>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Stock> UpdateAsync(int id, Stock entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
