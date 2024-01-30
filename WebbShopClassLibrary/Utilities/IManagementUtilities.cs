using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Utilities
{
    public interface IManagementUtilities
    {
        Task<List<Staff>> GetStaffIdsForOrder(int orderId);
    }
}