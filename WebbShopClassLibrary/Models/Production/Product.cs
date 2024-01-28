using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Production
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int? StockId { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        [JsonIgnore]
        public Color? Color { get; set; }
        [JsonIgnore]
        public Size? Size { get; set; }
        
        public Stock? Stock { get; set; } = new Stock();
    }
}
