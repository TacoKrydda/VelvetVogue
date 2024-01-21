using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetCategorysAsync();
    }
}