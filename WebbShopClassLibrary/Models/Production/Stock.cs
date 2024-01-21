using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebbShopClassLibrary.Models.Production
{
    public class Stock
    {
        public int StockId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
