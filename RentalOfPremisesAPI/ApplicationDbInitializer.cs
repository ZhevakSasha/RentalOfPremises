using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace RentalOfPremisesAPI
{
    public class ApplicationDbInitializer
    {
        public static async Task SeedUsers(UserManager<Client> userManager)
        {
            var admin = await userManager.FindByNameAsync("Manager");

            if (admin != null)
            {
                return;
            }

            var user = new Client()
            {
                UserName = "Manager",
                Email = "admin@gmail.com",
                LockoutEnabled = false
            };

            var result = await userManager.CreateAsync(user, "Admin*123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Manager");
            }
        }

    }
}
