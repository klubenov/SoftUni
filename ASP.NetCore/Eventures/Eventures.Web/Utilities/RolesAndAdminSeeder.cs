namespace Eventures.Web.Utilities
{
    using Eventures.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    public class RolesAndAdminSeeder
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<User> userManager;

        public RolesAndAdminSeeder(
                RoleManager<IdentityRole> roleManager,
                UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void Seed()
        {
            ///Seeding the roles
            if (roleManager.RoleExistsAsync("User").GetAwaiter().GetResult() == false)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }
            if (roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            ///Crating the admin 
            //if (userManager.Users.Any(x => x.UserName == "Admin") == false)
            //{
            //    var user = new User
            //    {
            //        UserName = "Admin",
            //        Email = "Admin@Admin.Admin",
            //        FirstName = "Admin1",
            //        LastName = "Admin2",
            //    };
            //    var result = await userManager.CreateAsync(user, "Admin");
            //    if (result.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(user, "Admin");
            //    }
            //}

            if (userManager.Users.Count() == 1)
            {
                var user = userManager.Users.First();

                userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }
    }
}
