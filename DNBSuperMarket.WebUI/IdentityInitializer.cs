using DNBSuperMarket.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DNBSuperMarket.WebUI
{
    public class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });

                var memberRole = await roleManager.FindByNameAsync("Member");

                if (memberRole == null)
                {
                    await roleManager.CreateAsync(new AppRole { Name = "Member" });
                }

                var adminUser = await userManager.FindByNameAsync("omer");

                if (adminUser == null)
                {
                    AppUser user = new AppUser
                    {
                        Name = "Ömercan",
                        SurName = "Dinç",
                        UserName = "omercandinc",
                        Email = "omercan74@gmail.com"
                    };
                    await userManager.CreateAsync(user, "1");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        internal static object SeedData(object userManager, object roleManager)
        {
            throw new NotImplementedException();
        }
    }
}
