using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Services.Sales
{
    public class CustomerService : ICustomerService
    {
        private readonly WebbShopContext _context;

        public CustomerService(WebbShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            if (_context == null)
            {
                return Enumerable.Empty<Customer>();
            }
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(Customer));
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
