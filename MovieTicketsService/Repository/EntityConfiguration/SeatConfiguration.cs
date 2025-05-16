using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.EntityConfiguration;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.UUID);

        builder.Property(s => s.UUID)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(s => s.ScreeningRoom)
            .WithMany(sr => sr.Seats)
            .HasForeignKey(sr => sr.ScreeningRoomId);

        builder.Property(s => s.RowNumber)
            .IsRequired();

        builder.Property(s => s.SeatNumber)
            .IsRequired();
    }
}