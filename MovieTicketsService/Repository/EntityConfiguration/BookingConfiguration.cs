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

        builder.Property(b => b.MovieShowUUID)
            .IsRequired();

        builder.Property(b => b.SeatUUID)
            .IsRequired();

        builder.Property(b => b.UserUUID)
            .IsRequired();

        builder.Property(b => b.Status)
            .IsRequired()
            .HasDefaultValue(BookingStatus.Confirmed);
    }
}