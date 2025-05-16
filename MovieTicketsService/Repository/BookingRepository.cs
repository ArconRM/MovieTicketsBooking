using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class BookingRepository : BaseRepository<Booking>, IBookingRepository
{
    private readonly MovieTicketsContext _context;

    public BookingRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Booking> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<Booking> set = _context.Bookings;
        Booking result = await set
            .AsNoTracking()
            .Include(b => b.MovieShow)
            .Include(b => b.Seat)
            .FirstOrDefaultAsync(b => b.UUID == id, token);
        return result;
    }
}