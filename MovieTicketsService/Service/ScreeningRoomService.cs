using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class ScreeningRoomService : BaseService<ScreeningRoom>, IScreeningRoomService
{
    private readonly IScreeningRoomRepository _repository;

    public ScreeningRoomService(IScreeningRoomRepository repository) : base(repository)
    {
        _repository = repository;
    }
}