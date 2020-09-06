using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Entity
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string OrderNumber { get; set; }
        public string OrderState { get; set; }
    }
}
