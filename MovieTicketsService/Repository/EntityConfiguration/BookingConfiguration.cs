using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.EntityConfiguration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.UUID);

        builder.Property(b => b.UUID)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(b => b.MovieShow)
            .WithMany(m => m.Bookings)
            .HasForeignKey(b => b.MovieShowUUID);

        builder
            .HasOne(b => b.Seat)
            .WithMany()
            .HasForeignKey(b => b.SeatUUID);

        builder.Property(b => b.UserUUID)
            .IsRequired();

        builder.Property(b => b.TotalPrice)
            .IsRequired();

        builder.Property(b => b.Status)
            .IsRequired()
            .HasDefaultValue(BookingStatus.Confirmed);
    }
}