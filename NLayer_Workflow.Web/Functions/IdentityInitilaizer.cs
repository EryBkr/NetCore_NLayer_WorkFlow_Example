using Microsoft.AspNetCore.Identity;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Functions
{
    public static class IdentityInitilaizer
    {
        public static async Task SeedData(UserManager<AppUser> user,RoleManager<AppRole> role) //Uygulama başladığında Admin i oluşturacak Class
        {
            var adminRole = await role.FindByNameAsync("Admin");
            if (adminRole==null)
            {
                await role.CreateAsync(new AppRole { Name="Admin"});
            }
            var memberRole = await role.FindByNameAsync("Member");
            if (memberRole==null)
            {
                await role.CreateAsync(new AppRole { Name="Member"});
            }
            var adminUser = await user.FindByNameAsync("Eray");
            if (adminUser==null)
            {
                var appUser = new AppUser
                {
                    UserName="Blackerback",
                    Name = "Eray",
                    Surname = "Bakır",
                    Email="eray.bkr94@gmail.com"
                };
                await user.CreateAsync(appUser, "1");
                await user.AddToRoleAsync(appUser,"Admin");
            }
        }
    }
}
