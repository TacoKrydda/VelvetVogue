using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface ISizeService
    {
        Task<Size> CreateSizeAsync(Size size);
        Task<IEnumerable<Size>> GetSizesAsync();
    }
}