using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zoo.Animal.Domain;
using Zoo.Shared.Infrastructure.Persistence.EntityFramework;

namespace ZooBackend.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new[]
            {
                new IdentityRole {Name = "Member"},
                new IdentityRole {Name = "Admin"},
                new IdentityRole {Name = "Supervisor"}
            };

            foreach (var role in roles) await roleManager.CreateAsync(role);

            var admin = new IdentityUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {"Admin", "Supervisor"});
        }

        public static async Task SeedAnimals(ZooContext context)
        {
            if (await context.Animals.AnyAsync()) return;

            var animalData = await File.ReadAllTextAsync("Data/AnimalSeedData.json");
            var animals = JsonSerializer.Deserialize<List<ZooAnimal>>(animalData);
            if (animals == null) return;

            await context.Animals.AddRangeAsync(animals);
            await context.SaveChangesAsync();
        }
    }
}