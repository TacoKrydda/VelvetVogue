using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IColorService
    {
        Task<Color> CreateColorsAsync(Color color);
        Task<IEnumerable<Color>> GetColorsAsync();
    }
}