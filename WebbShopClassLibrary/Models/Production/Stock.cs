using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebbShopClassLibrary.Models.Production
{
    public class Stock
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
