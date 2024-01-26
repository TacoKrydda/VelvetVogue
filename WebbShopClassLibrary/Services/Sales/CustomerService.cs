using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
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
        public Task<Customer> CreateAsync(Customer entity)
        {
            return _genericService.CreateAsync(entity);
        }

        public Task<Customer> DeleteAsync(int id)
        {
            return _genericService.DeleteAsync(id);
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return _genericService.GetAllAsync();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return _genericService.GetByIdAsync(id);
        }

        public Task<Customer> UpdateAsync(int id, Customer entity)
        {
            if (entity.Id != id)
            {
                throw new ArgumentException($"Entity {entity.Id} does not match the provided id {id}");
            }
            return _genericService.UpdateAsync(id, entity);
        }
    }
}
