using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Utilities
{
    public class ManagementUtilities : IManagementUtilities
    {
        private readonly WebbShopContext _context;

        public ManagementUtilities(WebbShopContext context)
        {
            _context = context;
        }
        public async Task<List<Staff>> GetStaffIdsForOrder(int orderId)
        {
            var staffIdsForOrder = await _context.OrderStaffAssignments
                                    .Where(osa => osa.OrderId == orderId)
                                    .Select(osa => osa.Staff)
                                    .ToListAsync();
            if (staffIdsForOrder == null)
            {
                throw new ArgumentException($"No staff has worked for this order");
            }

            return staffIdsForOrder;
        }
    }
}
