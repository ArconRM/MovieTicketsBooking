using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class TheaterService : BaseService<Theater>, ITheaterService
{
    private readonly IRepository<Theater> _repository;

    public TheaterService(IRepository<Theater> repository) : base(repository)
    {
        _repository = repository;
    }
}