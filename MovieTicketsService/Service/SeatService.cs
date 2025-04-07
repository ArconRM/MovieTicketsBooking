using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class SeatService : BaseService<Seat>, ISeatService
{
    private readonly IRepository<Seat> _repository;

    public SeatService(IRepository<Seat> repository) : base(repository)
    {
        _repository = repository;
    }
}