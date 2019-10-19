using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public static class SeedAdmin
    {
        public static void SeedData
    (UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
        }

        public static void SeedUsers
                (UserManager<IdentityUser> userManager)
        {
            if(userManager.FindByNameAsync (DefaultRoles.UserEmail).Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = DefaultRoles.UserEmail;
                user.Email = DefaultRoles.Admin;

                IdentityResult result = userManager.CreateAsync
                (user, DefaultRoles.UserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        DefaultRoles.Admin).Wait();
                }
            }
        }

        public static void SeedRoles
        (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(DefaultRoles.Admin).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = DefaultRoles.Admin;
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}

