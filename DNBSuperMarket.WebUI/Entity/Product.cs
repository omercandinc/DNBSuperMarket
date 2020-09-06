using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Entity
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public int StockQuantity { get; set; }
		public string Description { get; set; }
		public DateTime DateAdded { get; set; }

		public List<ProductCategory> ProductCategories { get; set; }
	}
}
