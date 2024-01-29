using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Sales
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }

        //[JsonIgnore]
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public List<OrderStaffAssignment>? OrderStaffAssignments { get; set; } = new List<OrderStaffAssignment>();
    }
}
