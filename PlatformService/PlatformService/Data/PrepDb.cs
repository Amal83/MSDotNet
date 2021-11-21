using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "YO", Publisher = "Me", Cost = "Not free" },
                    new Platform() { Name = "Jay", Publisher = "Mart", Cost = "Ok free" },
                    new Platform() { Name = "PC", Publisher = "Mac", Cost = "Maybe free" },
                    new Platform() { Name = "Ice", Publisher = "Freeze", Cost = "Free" },
                    new Platform() { Name = "Bank", Publisher = "DB", Cost = "All free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
