using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class MovieShowService : BaseService<MovieShow>, IMovieShowService
{
    private readonly IMovieShowRepository _repository;

    public MovieShowService(IMovieShowRepository repository) : base(repository)
    {
        _repository = repository;
    }
}