using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopClassLibrary.Models.Sales
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? StaffId { get; set; }
        public string? Orders { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
    }
}
