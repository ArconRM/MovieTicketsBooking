using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.EntityConfiguration;

public class ScreeningRoomConfiguration : IEntityTypeConfiguration<ScreeningRoom>
{
    public void Configure(EntityTypeBuilder<ScreeningRoom> builder)
    {
        builder.HasKey(sr => sr.UUID);

        builder.Property(sr => sr.UUID)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(sr => sr.Theater)
            .WithMany(t => t.ScreeningRooms)
            .HasForeignKey(sr => sr.TheaterId);

        builder.Property(sr => sr.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(sr => sr.Capacity)
            .IsRequired();
    }
}