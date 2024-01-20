using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<IEnumerable<Brand>> GetBrandsAsync();
    }
}