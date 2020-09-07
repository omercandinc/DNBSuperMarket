using System;
using System.Collections.Generic;

#nullable disable

namespace DNBSuperMarket.WebAPI.Models
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }
        public string OrderNumber { get; set; }
        public string OrderState { get; set; }
    }
}
