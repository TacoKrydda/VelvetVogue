using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class ColorService : IGenericService<Color>
    {
        private readonly IGenericService<Color> _genericService;

        public ColorService(GenericService<Color> genericService)
        {
            _genericService = genericService;
        }
        public async Task<Color> CreateAsync(Color entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Color> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Color>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Color> UpdateAsync(int id, Color entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
