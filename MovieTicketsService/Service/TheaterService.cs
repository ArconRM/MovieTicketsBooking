using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class TheaterService : BaseService<Theater>, ITheaterService
{
    private readonly ITheaterRepository _repository;

    public TheaterService(ITheaterRepository repository) : base(repository)
    {
        _repository = repository;
    }
}