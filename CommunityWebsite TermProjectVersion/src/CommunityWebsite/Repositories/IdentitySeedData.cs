using CommunityWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public class IdentitySeedData
    {
        private const string adminEmail = "dancewme0102@yahoo.com";
        private const string adminPassword = "Admin_123";
        private const string password = "Member_123";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            UserManager<Member> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<Member>>();

            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();

            if (!context.Roles.Any())
            {
                IdentityRole admin = new IdentityRole()
                {
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                };

                IdentityRole member = new IdentityRole()
                {
                    Name = "Member",
                    NormalizedName = "Member"
                };

                var adminrolecreate = await roleManager.CreateAsync(admin);
                var memberrolecreate = await roleManager.CreateAsync(member);
            }

            if (!context.Users.Any())
            {
                Member admin = await userManager.FindByEmailAsync(adminEmail);
                if (admin == null)
                {
                    admin = new Member()
                    {
                        FirstName = "Christina",
                        LastName = "Lindsay",
                        UserName = "C_Lindsay",
                        Email = "dancewme0102@yahoo.com",
                        AvatarImg = "~/lib/images/head_shot.jpg",
                        Name = "Christina Lindsay"
                    };
                }
                var admincreate = await userManager.CreateAsync(admin, adminPassword);
                var adminrole = await userManager.AddToRoleAsync(admin, "Administrator");

                Member member = await userManager.FindByEmailAsync("jsmith@member.com");
                if (member == null)
                {
                    member = new Member()
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        UserName = "J_Smith",
                        Email = "jsmith@member.com",
                        Name = "John Smith"
                    };

                    var membercreate = await userManager.CreateAsync(member, password);
                    var memberrole = await userManager.AddToRoleAsync(member, "Member");

                }

                member = await userManager.FindByEmailAsync("mbrown@member.com");
                if (member == null)
                {
                    member = new Member()
                    {
                        FirstName = "Mike",
                        LastName = "Brown",
                        UserName = "M_Brown",
                        Email = "mbrown@member.com",
                        Name = "Mike Brown"
                    };

                    var membercreate = await userManager.CreateAsync(member, password);
                    var memberrole = await userManager.AddToRoleAsync(member, "Member");
                }

                member = await userManager.FindByEmailAsync("ajohnson@member.com");
                if (member == null)
                {
                    member = new Member()
                    {
                        FirstName = "Andrea",
                        LastName = "Johnson",
                        UserName = "A_Johnson",
                        Email = "ajohnson@member.com",
                        Name = "Andrea Johnson"
                    };

                    var membercreate = await userManager.CreateAsync(member, password);
                    var memberrole = await userManager.AddToRoleAsync(member, "Member");
                }

                member = await userManager.FindByEmailAsync("msanchez@member.com");
                if (member == null)
                {
                    member = new Member()
                    {
                        FirstName = "Miguel",
                        LastName = "Sanchez",
                        UserName = "M_Sanchez",
                        Email = "msanchez@member.com",
                        Name = "Miguel Sanchez"
                    };

                    var membercreate = await userManager.CreateAsync(member, password);
                    var memberrole = await userManager.AddToRoleAsync(member, "Member");

                    if (memberrole.Succeeded)
                    {
                        SeedData.EnsurePopulated(app);
                    }
                }
            }
        }
    }
}
