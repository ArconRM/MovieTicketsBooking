using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class ScreeningRoomService : BaseService<ScreeningRoom>, IScreeningRoomService
{
    private readonly IRepository<ScreeningRoom> _repository;

    public ScreeningRoomService(IRepository<ScreeningRoom> repository) : base(repository)
    {
        _repository = repository;
    }
}