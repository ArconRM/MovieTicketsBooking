using Common.Enums;
using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class SeatRepository : BaseRepository<Seat>, ISeatRepository
{
    private readonly MovieTicketsContext _context;

    public SeatRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Seat> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<Seat> set = _context.Seats;
        Seat result = await set
            .AsNoTracking()
            .Include(s => s.ScreeningRoom)
            .FirstOrDefaultAsync(s => s.UUID == id, token);
        return result;
    }

    public async Task<IEnumerable<Seat>> GetAvailableSeatsByMovieShowUuid(Guid movieShowUuid, CancellationToken token)
    {
        var screeningRoomUuid = await _context.MovieShows
            .Where(ms => ms.UUID == movieShowUuid)
            .Select(ms => ms.ScreeningRoomUUID)
            .FirstOrDefaultAsync(token);

        var bookedSeats = await _context.Bookings
            .Where(b => b.MovieShowUUID == movieShowUuid &&
                        (b.Status == BookingStatus.CheckedIn || b.Status == BookingStatus.Confirmed))
            .Select(b => b.SeatUUID)
            .ToHashSetAsync(token);

        var availableSeats = await _context.Seats
            .Where(s => s.ScreeningRoomUUID == screeningRoomUuid && !bookedSeats.Contains(s.UUID))
            .ToListAsync(token);

        return availableSeats;
    }
}