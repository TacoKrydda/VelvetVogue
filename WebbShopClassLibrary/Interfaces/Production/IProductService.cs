using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductAsync();
    }
}