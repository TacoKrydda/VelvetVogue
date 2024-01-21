using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Interfaces.Sales
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}