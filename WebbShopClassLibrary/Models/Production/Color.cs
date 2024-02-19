﻿using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Production
{
    public class Color
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
