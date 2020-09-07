using System;
using System.Collections.Generic;

#nullable disable

namespace DNBSuperMarket.WebAPI.Models
{
    public partial class Order
    {
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Adres { get; set; }
        public string AdresTanimi { get; set; }
        public int OrderState { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Telefon { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
    }
}
