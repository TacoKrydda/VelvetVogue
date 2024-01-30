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
        public async Task<Staff> CreateAsync(Staff entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Staff> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Staff>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync("OrderStaffAssignments");
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Staff> UpdateAsync(int id, Staff entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
