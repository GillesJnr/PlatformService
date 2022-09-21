using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Database with Data --------->");
                context.Platforms.AddRange(
                    new Platform() { Name = "DotNet", Cost = "Free", Publisher = "Microsoft" },
                    new Platform() { Name = "SQL Server Express", Cost = "Free", Publisher = "Microsoft" },
                    new Platform() { Name = "Kubernetes", Cost = "Free", Publisher = "Cloud Native Computing Foundation" }
                    );
                context.SaveChanges();
            }
        }
    }
}
