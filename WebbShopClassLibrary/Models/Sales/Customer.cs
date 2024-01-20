using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebbShopClassLibrary.Models.Sales
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; } 
        public string? Street { get; set; }
        public string? City { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
