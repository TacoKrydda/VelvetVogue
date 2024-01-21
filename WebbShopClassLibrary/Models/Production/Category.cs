using System.Text.Json.Serialization;

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
