using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.CustomIdentityExtension;
using DNBSuperMarket.WebUI.Entity;
using DNBSuperMarket.WebUI.Repository.Abstract;
using DNBSuperMarket.WebUI.Repository.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DNBSuperMarket.WebUI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DNBSuperMarketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddTransient<IProductRepository, EfProductRepository>();
			services.AddTransient<ICategoryRepository, EfCategoryRepository>();
			services.AddTransient<IUnitOfWork, EfUnitOfWork>();
			services.AddControllersWithViews();
			services.AddCustomIdentity();


			services.AddMemoryCache();
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();
			app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "products",
					pattern: "products/{category?}",
					defaults: new { controller = "Product", action = "List" });
				});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			SeedData.EnsurePopulated(app);
			IdentityInitializer.SeedData(userManager, roleManager).Wait();
			//SeedIdentity.CreateIdentityUsers(app.ApplicationServices,Configuration).Wait();
		}
	}
}
