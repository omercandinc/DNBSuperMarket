using System;
using System.Collections.Generic;

#nullable disable

namespace DNBSuperMarket.WebAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
