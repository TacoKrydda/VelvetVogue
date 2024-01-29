using System.Text.Json.Serialization;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Utilities
{
    public class testOrder
    {
        public int CustomerId { get; set; } = 1;
        public int? StaffId { get; set; } = 1;
        public string? OrderStatus { get; set; } = "Pending";
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }

        //[JsonIgnore]
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>
        {
            new CartItem
            {
                Product = new Product{ Price = 199}, Quantity = 4
            }
        };
    }
}
