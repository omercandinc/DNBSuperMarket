using DNBSuperMarket.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Models
{
    public class CartModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
