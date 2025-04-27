using Core.Interfaces;
using MovieDataService.Entities;

namespace MovieDataService.Service.Interfaces;

public interface IMovieService : IService<Movie>
{
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreUUID, CancellationToken token);
}