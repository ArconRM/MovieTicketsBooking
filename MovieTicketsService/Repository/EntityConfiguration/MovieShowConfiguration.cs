using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.EntityConfiguration;

public class MovieShowConfiguration : IEntityTypeConfiguration<MovieShow>
{
    public void Configure(EntityTypeBuilder<MovieShow> builder)
    {
        builder.HasKey(ms => ms.UUID);

        builder.Property(ms => ms.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(ms => ms.MovieUUID)
            .IsRequired();

        builder.Property(ms => ms.ScreeningRoomUUID)
            .IsRequired();

        builder.Property(ms => ms.StartTime)
            .IsRequired();

        builder.Property(ms => ms.EndTime)
            .IsRequired();

        builder.Property(ms => ms.Price)
            .IsRequired();
    }
}