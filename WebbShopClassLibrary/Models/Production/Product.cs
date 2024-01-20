using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopClassLibrary.Models.Production
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int StockId { get; set; }

        public Brand? Brand { get; set; }
        public Category? Category { get; set; }
        public Color? Color { get; set; }
        public Size? Size { get; set; }
        public Stock? Stock { get; set; }
    }
}
