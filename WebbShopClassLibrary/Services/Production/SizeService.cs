using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class SizeService : IGenericService<Size>
    {
        private readonly GenericService<Size> _genericService;

        public SizeService(GenericService<Size> genericService)
        {
            _genericService = genericService;
        }

        public async Task<Size> CreateAsync(Size entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Size> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Size>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Size> UpdateAsync(int id, Size entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
