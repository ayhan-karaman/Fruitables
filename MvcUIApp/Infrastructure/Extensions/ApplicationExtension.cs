using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace MvcUIApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

            if(context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
        }

        
      
        public static async void ConfigureDefaultAdminUserAsync(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string password = "Admin+1234";
            UserManager<AppUser> userManager = 
            app.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<AppUser>>();


            RoleManager<AppRole> roleManager = 
            app.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<AppRole>>();

            
            AppUser? user = await userManager.FindByNameAsync(adminUser);
            if(user is null)
            {
                user = new AppUser()
                {
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = adminUser,
                    Email = "admin@admin.com",
                    PhoneNumber = "5351112233",
                    ImageUrl = "/img/avatar.jpg"
                };
                var result = await userManager.CreateAsync(user, password);
                
                if(!result.Succeeded)
                {
                    throw new Exception("Admin user could not created!");
                }
                var roleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(x => x.Name).ToList());
                
                if(!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for Admin");

                var claimResult = await userManager.AddClaimsAsync(user, new List<Claim>(){
                     new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                     new Claim(ClaimTypes.Email, user.Email)
                });

                if(!claimResult.Succeeded)
                    throw new Exception("System have problems with claim defination for Admin");
            }
        }
    }
}