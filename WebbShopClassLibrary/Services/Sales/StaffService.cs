using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class StaffService : IGenericService<Staff>
    {
        private readonly IGenericService<Staff> _genericService;

        public StaffService(GenericService<Staff> genericService)
        {
            _genericService = genericService;
        }
        public Task<Staff> CreateAsync(Staff entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Staff> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Staff>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Staff> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Staff> UpdateAsync(int id, Staff entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
