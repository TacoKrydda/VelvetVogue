using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Services.Production
{
    public class ColorService : IGenericService<Color>
    {
        private readonly GenericService<Color> _genericService;

        public ColorService(GenericService<Color> genericService)
        {
            _genericService = genericService;
        }

        public Task<IEnumerable<Color>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Color> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Color> CreateAsync(Color entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Color> UpdateAsync(int id, Color entity)
        {
            return _genericService.UpdateAsync(id, entity);
        }

        public Task<Color> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }
    }
}
