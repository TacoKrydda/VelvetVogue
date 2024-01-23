using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand> GetBrandByIdAsync(int id);
        Task<Brand> UpdateBrandAsync(int id, Brand brand);
        Task<Brand> DeleteBrand(int id);
        Task<Brand> FindBrandByIdAsync(int id);
    }
}