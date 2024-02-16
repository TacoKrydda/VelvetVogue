using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product entity);
        Task<Product> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(int id, Product entity);
    }
}