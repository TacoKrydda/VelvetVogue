using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.DTO;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Utilities
{
    public class ManagementUtilities
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
            return staffIdsForOrder;
        }
    }
}
