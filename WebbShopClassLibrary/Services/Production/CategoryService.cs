using WebbShopClassLibrary.Interfaces;
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
        public async Task<Category> CreateAsync(Category entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Category> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Category> UpdateAsync(int id, Category entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
