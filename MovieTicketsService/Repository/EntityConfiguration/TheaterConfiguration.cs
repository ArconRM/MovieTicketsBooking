using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.EntityConfiguration;

public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        builder.HasKey(t => t.UUID);

        builder.Property(t => t.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(t => t.Location)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(t => t.ContactInfo)
            .IsRequired()
            .HasMaxLength(255);
    }
}