﻿using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Sales
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
