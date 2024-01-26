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
        public Task<Brand> CreateAsync(Brand entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Brand> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Brand>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Brand> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Brand> UpdateAsync(int id, Brand entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
