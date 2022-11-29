using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SchoolPortalApi.Data.Entities;
using SchoolPortalAPI.Data;

namespace SchoolPortalApi.Core.Services
{
    public static class SeedingUsers
    {
        public static async void Seeds(UserManager<User> userManager, IConfiguration config , DataContext context)
        {
            var admin = new User()
            {
                FirstName = "Hongleang",
                LastName = "Lim",
                UserName = "admin",
                Email = "admin@gmail.com",
                DateOfBirth = new DateTime(1994, 08, 17),
                Gender = "male",
                HouseId = 1
            };

            try
            {
                if (!context.Users.Any())
                {
                    await userManager.CreateAsync(admin, config["Admin:Password"]);
                    await userManager.AddToRoleAsync(admin, "admin");
                    await context.SaveChangesAsync();
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong when attemps to create an admin User.", ex);
            }
        }
    }
}
