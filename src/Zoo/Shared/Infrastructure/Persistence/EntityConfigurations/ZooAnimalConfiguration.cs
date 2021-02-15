using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoo.Animal.Domain;

namespace Zoo.Shared.Infrastructure.Persistence.EntityConfigurations
{
    public class ZooAnimalConfiguration : IEntityTypeConfiguration<ZooAnimal>
    {
        public void Configure(EntityTypeBuilder<ZooAnimal> builder)
        {
            builder.ToTable("animal");
        }
    }
}