using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class CategoryService : IGenericService<Category>
    {
        private readonly IGenericService<Category> _genericService;

        public CategoryService(GenericService<Category> genericService)
        {
            _genericService = genericService;
        }
        public Task<Category> CreateAsync(Category entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Category> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Category> UpdateAsync(int id, Category entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
