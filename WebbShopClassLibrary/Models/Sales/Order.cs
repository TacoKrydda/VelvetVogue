﻿using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Sales
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? StaffId { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public Decimal TotalPrice { get; set; }

        //[JsonIgnore]
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
        [JsonIgnore]
        public Customer? Customer { get; set; }
        [JsonIgnore]
        public Staff? Staff { get; set; }
    }
}
