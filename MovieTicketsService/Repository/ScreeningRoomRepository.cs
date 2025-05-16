using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class ScreeningRoomRepository : BaseRepository<ScreeningRoom>, IScreeningRoomRepository
{
    private readonly MovieTicketsContext _context;

    public ScreeningRoomRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ScreeningRoom> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<ScreeningRoom> set = _context.ScreeningRooms;
        ScreeningRoom result = await set
            .AsNoTracking()
            .Include(sr => sr.Theater)
            .FirstOrDefaultAsync(sr => sr.UUID == id, token);
        return result;
    }
}