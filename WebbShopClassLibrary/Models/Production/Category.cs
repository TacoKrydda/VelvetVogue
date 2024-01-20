using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebbShopClassLibrary.Models.Production
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
