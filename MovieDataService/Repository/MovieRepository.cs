using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieDataContext _context;

    public MovieRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreUUID, CancellationToken token)
    {
        DbSet<Movie> set = _context.Set<Movie>();
        List<Movie> result = await set
            .AsNoTracking()
            .Where(m => m.Genres
                .Select(g => g.UUID)
                .Contains(genreUUID)
            )
            .ToListAsync();
        return result;
    }

    public override async Task<Movie> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<Movie> set = _context.Movies;
        Movie result = await set
            .AsNoTracking()
            .Include(m => m.Genres)
            .Include(m => m.Producer)
            .Include(m => m.Actors)
            .FirstOrDefaultAsync(m => m.UUID == id);
        return result;
    }

    public override async Task<Movie> CreateAsync(Movie entity, CancellationToken token)
    {
        DbSet<Movie> moviesSet = _context.Movies;

        foreach (Genre genre in entity.Genres)
        {
            if (genre.UUID != Guid.Empty)
            {
                _context.Attach(genre);
                _context.Entry(genre).State = EntityState.Unchanged;
            }
        }

        foreach (Actor actor in entity.Actors)
        {
            if (actor.UUID != Guid.Empty)
            {
                _context.Attach(actor);
                _context.Entry(actor).State = EntityState.Unchanged;
            }
        }

        await moviesSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}