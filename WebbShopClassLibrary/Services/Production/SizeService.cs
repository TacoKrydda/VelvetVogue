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

        public Task<IEnumerable<Size>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Size> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Size> CreateAsync(Size entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Size> UpdateAsync(int id, Size entity)
        {
            if (entity.SizeId != id)
            {
                throw new ArgumentException($"SizeId {entity.SizeId} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }

        public Task<Size> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }
    }
}
