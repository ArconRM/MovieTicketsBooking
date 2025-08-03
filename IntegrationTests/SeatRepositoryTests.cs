using Common.Enums;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository;

namespace IntegrationTests;

public class SeatRepositoryTests : IAsyncLifetime
{
    private MovieTicketsContext _context;
    private SeatRepository _repository;
    private DbContextOptions<MovieTicketsContext> _options;

    public async Task InitializeAsync()
    {
        _options = new DbContextOptionsBuilder<MovieTicketsContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new MovieTicketsContext(_options);
        await _context.Database.EnsureCreatedAsync();
        _repository = new SeatRepository(_context);
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task GetAvailableSeatsByMovieShowUuid_ShouldReturnUnbookedSeats()
    {
        // Arrange
        var movieShowUuid = Guid.NewGuid();
        var screeningRoomUuid = Guid.NewGuid();

        var seat1 = new Seat { UUID = Guid.NewGuid(), ScreeningRoomUUID = screeningRoomUuid };
        var seat2 = new Seat { UUID = Guid.NewGuid(), ScreeningRoomUUID = screeningRoomUuid };
        var seat3 = new Seat { UUID = Guid.NewGuid(), ScreeningRoomUUID = screeningRoomUuid }; // will be booked

        var booking = new Booking
        {
            UUID = Guid.NewGuid(),
            MovieShowUUID = movieShowUuid,
            SeatUUID = seat3.UUID,
            Status = BookingStatus.Confirmed
        };

        using (var context = new MovieTicketsContext(_options))
        {
            context.MovieShows.Add(new MovieShow
            {
                UUID = movieShowUuid,
                ScreeningRoomUUID = screeningRoomUuid
            });

            context.Seats.AddRange(seat1, seat2, seat3);
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        IEnumerable<Seat> result;

        // Act
        using (var context = new MovieTicketsContext(_options))
        {
            var repository = new SeatRepository(context);
            result = await repository.GetAvailableSeatsByMovieShowUuid(movieShowUuid, CancellationToken.None);
        }

        // Assert
        var availableSeatUuids = result.Select(s => s.UUID).ToHashSet();

        Assert.Contains(seat1.UUID, availableSeatUuids);
        Assert.Contains(seat2.UUID, availableSeatUuids);
        Assert.DoesNotContain(seat3.UUID, availableSeatUuids);
        Assert.Equal(2, availableSeatUuids.Count);
    }
}