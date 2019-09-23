using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IISportSchool.Models
{
    public class SeedAdminUser
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public SeedAdminUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public async void EnsurePopulated(IApplicationBuilder builder)
        {
            var context = builder.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var adminRole = new IdentityRole(DefaultRoles.Admin);
            var moderatorRole = new IdentityRole(DefaultRoles.Moderator);

            await _roleManager.CreateAsync(adminRole);
            await _roleManager.CreateAsync(moderatorRole);

            var user = new IdentityUser { UserName = DefaultRoles.UserEmail, Email = DefaultRoles.UserEmail };
            var result = await _userManager.CreateAsync(user, DefaultRoles.UserPassword);

            context.SaveChanges();
        }
    }
}
