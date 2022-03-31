using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class AppSeedUsers
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppSeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUsersAsync()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

            if (!userManager.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Gender = "Male",
                    ContactNumber = "9876543210",
                    DateOfBirth = new DateTime(2000,02,02),
                    Password = "admin@123",
                    ConfirmPassword = "admin@123",
                    SecretQuestions = "fav color",
                    Answer = "blue"
                };
                
                await userManager.CreateAsync(admin, "admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
