using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class SeatService : BaseService<Seat>, ISeatService
{
    private readonly ISeatRepository _repository;

    public SeatService(ISeatRepository repository) : base(repository)
    {
        _repository = repository;
    }
}