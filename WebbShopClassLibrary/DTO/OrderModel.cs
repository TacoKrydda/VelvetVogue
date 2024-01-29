using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.DTO
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int StaffId { get; set; }
        public Staff? Staffs { get; set; }
    }
}
