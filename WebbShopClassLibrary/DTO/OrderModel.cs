using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.DTO
{
    public class OrderModel
    {
        public List<CartItem>? CartItems { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderStatus { get; set; }
    }
}
