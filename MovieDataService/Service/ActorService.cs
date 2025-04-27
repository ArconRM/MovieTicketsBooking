using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class ActorService : BaseService<Actor>, IActorService
{
    private readonly IActorRepository _repository;

    public ActorService(IActorRepository repository) : base(repository)
    {
        _repository = repository;
    }
}