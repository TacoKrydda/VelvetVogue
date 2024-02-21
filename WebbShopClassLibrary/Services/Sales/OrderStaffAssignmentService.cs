using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class OrderStaffAssignmentService : IGenericService<OrderStaffAssignment>
    {
        private readonly IGenericService<OrderStaffAssignment> _genericService;

        public OrderStaffAssignmentService(GenericService<OrderStaffAssignment> genericService)
        {
            _genericService = genericService;
        }
        public async Task<OrderStaffAssignment> CreateAsync(OrderStaffAssignment entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<OrderStaffAssignment> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderStaffAssignment>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<OrderStaffAssignment> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<OrderStaffAssignment> UpdateAsync(int id, OrderStaffAssignment entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }

            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
