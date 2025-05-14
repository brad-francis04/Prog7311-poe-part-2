using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace YourProjectName.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            context.Database.EnsureCreated();

            // Check if any farmers already exist
            if (context.Farmers.Any())
                return; // Database has been seeded

            // Seed Farmers
            var farmers = new[]
            {
                new Farmer { Name = "John Doe", Location = "Free State", Email = "john@example.com" },
                new Farmer { Name = "Mary Smith", Location = "Limpopo", Email = "mary@example.com"}, 
            };

            context.Farmers.AddRange(farmers);
            context.SaveChanges();

            // Seed Products
            var products = new[]
            {
                new Product { Name = "Maize", Category = "Grain", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = farmers[0].Id },
                new Product { Name = "Tomatoes", Category = "Vegetable", ProductionDate = DateTime.Now.AddDays(-5), FarmerId = farmers[1].Id },
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
