using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class MovieShowRepository : BaseRepository<MovieShow>, IMovieShowRepository
{
    private readonly MovieTicketsContext _context;

    public MovieShowRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<MovieShow> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<MovieShow> set = _context.MovieShows;
        MovieShow result = await set
            .AsNoTracking()
            .Include(ms => ms.ScreeningRoom)
            .FirstOrDefaultAsync(ms => ms.UUID == id, token);
        return result;
    }
}