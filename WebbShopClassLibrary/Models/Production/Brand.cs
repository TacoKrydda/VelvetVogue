using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Production
{
    public class Brand
    {
        public int Id { get; set; }
        public string? BrandName { get; set; }

        [JsonIgnore]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
