using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDataService.Entities;

namespace MovieDataService.Repository.EntityConfiguration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.UUID);

        builder.Property(p => p.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);
    }
}