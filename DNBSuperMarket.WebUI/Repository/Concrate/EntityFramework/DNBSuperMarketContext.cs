using DNBSuperMarket.WebUI.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework
{
	public class DNBSuperMarketContext: IdentityDbContext<AppUser, AppRole, int>
	{
		public DNBSuperMarketContext(DbContextOptions<DNBSuperMarketContext> options) :base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderLine> OrderLine { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductCategory>()
				.HasKey(pk => new { pk.ProductId, pk.CategoryId});
			base.OnModelCreating(modelBuilder);
		}
	}
}
