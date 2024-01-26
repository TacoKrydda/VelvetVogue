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
        public Task<Color> CreateAsync(Color entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Color> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Color>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Color> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Color> UpdateAsync(int id, Color entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
