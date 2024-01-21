using WebbShopClassLibrary.Models.Production;

namespace WebbShopClassLibrary.Interfaces.Production
{
    public interface IStockService
    {
        Task<Stock> CreateStockAsync(Stock stock);
        Task<IEnumerable<Stock>> GetStocksAsync();
    }
}