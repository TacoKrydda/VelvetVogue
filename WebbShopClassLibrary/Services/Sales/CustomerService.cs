using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class CustomerService : IGenericService<Customer>
    {
        private readonly IGenericService<Customer> _genericService;

        public CustomerService(GenericService<Customer> genericService)
        {
            _genericService = genericService;
        }
        public async Task<Customer> CreateAsync(Customer entity)
        {
            return await _genericService.CreateAsync(entity);
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            return await _genericService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(params string[] includeProperties)
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<Customer> UpdateAsync(int id, Customer entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return await _genericService.UpdateAsync(id, entity);
        }
    }
}
