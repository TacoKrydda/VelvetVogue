using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Production
{
    public class Size
    {
        public int SizeId { get; set; }
        public string? SizeName { get; set; }

        [JsonIgnore]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
