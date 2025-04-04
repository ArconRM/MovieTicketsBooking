using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDataService.Entities;

namespace MovieDataService.Repository.EntityConfiguration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.UUID);

        builder.Property(m => m.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(m => m.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.Description)
            .HasMaxLength(1000);
    }
}