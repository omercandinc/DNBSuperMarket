using DNBSuperMarket.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			var context = app.ApplicationServices.GetRequiredService<DNBSuperMarketContext>();

			context.Database.Migrate();

			if(!context.Products.Any())
			{
				var products = new[]
				{
					new Product(){ProductName="Su",Price=1},
					new Product(){ProductName="Elma",Price=2},
					new Product(){ProductName="Domates",Price=3},
					new Product(){ProductName="Dezenfektan",Price=10},
					new Product(){ProductName="Sigara",Price=15},
					new Product(){ProductName="Kalem",Price=3}
				};

				context.Products.AddRange(products);

				var categories = new[]
				{
					new Category(){CategoryName="Meyve"},
					new Category(){CategoryName="Sebze"},
					new Category(){CategoryName="Sigara"},
					new Category(){CategoryName="Kırtasiye"},
			
				};

				context.Categories.AddRange(categories);

				var productcategories = new[]
				{
					new ProductCategory(){Product=products[0],Category=categories[1]},
					new ProductCategory(){Product=products[1],Category=categories[2]},
					new ProductCategory(){Product=products[2],Category=categories[3]},
					new ProductCategory(){Product=products[3],Category=categories[1]},
				};

				context.AddRange(productcategories);

				context.SaveChanges();


			}
		}

	}
}
