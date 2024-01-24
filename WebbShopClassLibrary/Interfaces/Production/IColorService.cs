using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllAsync();
        Task<Color> GetByIdAsync(int id);
        Task<Color> CreateAsync(Color color);
        Task<Color> UpdateAsync(int id, Color color);
        Task<Color> DeleteAsync(int id);
    }
}