using Core.Interfaces;
using MovieDataService.Entities;

namespace MovieDataService.Repository.Interfaces;

public interface IMovieRepository : IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreUUID, CancellationToken token);
}