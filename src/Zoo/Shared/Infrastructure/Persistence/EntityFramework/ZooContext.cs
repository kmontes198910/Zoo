using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoo.Animal.Domain;
using Zoo.Shared.Infrastructure.Persistence.EntityConfigurations;

namespace Zoo.Shared.Infrastructure.Persistence.EntityFramework
{
    public class ZooContext : IdentityDbContext
    {
        public DbSet<ZooAnimal> Animals { get; set; }

        public ZooContext(DbContextOptions<ZooContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ZooAnimalConfiguration());
        }
    }
}