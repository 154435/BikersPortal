using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using BikersPortal.Models;

namespace BikersPortal.Data
{
     // A singleton Class
        public static class ApplicationDbContextSeed
        {
            public static async Task SeedIdentityRolesAsync(RoleManager<IdentityRole> rolemanager)
            {
                foreach (MyIdentityRoleNames rolename in Enum.GetValues(typeof(MyIdentityRoleNames)))
                {
                    if (!await rolemanager.RoleExistsAsync(rolename.ToString()))
                    {
                        await rolemanager.CreateAsync(
                            new IdentityRole { Name = rolename.ToString() });
                    }
                }
            }

            public static async Task SeedIdentityUserAsync(UserManager<IdentityUser> usermanager)
            {
                IdentityUser user;

                user = await usermanager.FindByNameAsync("admin@demo.com");
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = "admin@demo.com",
                        Email = "admin@demo.com",
                        EmailConfirmed = true
                    };
                    await usermanager.CreateAsync(user, password: "Abhi@123");

                    await usermanager.AddToRolesAsync(user, new string[] {
                    MyIdentityRoleNames.AppAdmin.ToString(),
                    MyIdentityRoleNames.AppUser.ToString()
                });
                }

                user = await usermanager.FindByNameAsync("Abhi@gmail.com");
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = "Abhi@gmail.com",
                        Email = "Abhi@gmail.com",
                        EmailConfirmed = true
                    };
                    await usermanager.CreateAsync(user, password: "Abhi@123");
                    //await usermanager.AddToRolesAsync(user, new string[] {
                    //    MyIdentityRoleNames.AppUser.ToString()
                    //});
                    await usermanager.AddToRoleAsync(user, MyIdentityRoleNames.AppUser.ToString());
                }
            }

        }
    }

