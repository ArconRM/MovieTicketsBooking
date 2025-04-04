using Core.BaseEntities;
using Core.Interfaces;
using MoviesService.Entities;
using MoviesService.Services.Interfaces;

namespace MoviesService.Services;

public class MovieService : BaseService<Movie>, IMovieService
{
    private readonly IRepository<Movie> _repository;

    public MovieService(IRepository<Movie> repository) : base(repository)
    {
        _repository = repository;
    }
}