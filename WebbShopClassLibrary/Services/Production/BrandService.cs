using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class BrandService : IGenericService<Brand>
    {
        private readonly IGenericService<Brand> _genericService;

        public BrandService(GenericService<Brand> genericService)
        {
            _genericService = genericService;
        }
        public async Task<Brand> CreateAsync(Brand entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Brand> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Brand> UpdateAsync(int id, Brand entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
