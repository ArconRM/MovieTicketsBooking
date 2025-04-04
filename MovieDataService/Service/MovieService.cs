using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class MovieService : BaseService<Movie>, IMovieService
{
    private readonly IRepository<Movie> _repository;

    public MovieService(IRepository<Movie> repository) : base(repository)
    {
        _repository = repository;
    }
}