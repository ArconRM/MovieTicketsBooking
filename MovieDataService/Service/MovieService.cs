using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class MovieService : BaseService<Movie>, IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(Guid genreUUID, CancellationToken token)
    {
        return await _repository.GetMoviesByGenreAsync(genreUUID, token);
    }
}