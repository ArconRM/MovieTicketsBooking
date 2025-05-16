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
}