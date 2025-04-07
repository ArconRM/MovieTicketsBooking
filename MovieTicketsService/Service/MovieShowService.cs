using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class MovieShowService : BaseService<MovieShow>, IMovieShowService
{
    private readonly IRepository<MovieShow> _repository;

    public MovieShowService(IRepository<MovieShow> repository) : base(repository)
    {
        _repository = repository;
    }
}