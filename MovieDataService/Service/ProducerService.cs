using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class ProducerService : BaseService<Producer>, IProducerService
{
    private readonly IProducerRepository _repository;

    public ProducerService(IProducerRepository repository) : base(repository)
    {
        _repository = repository;
    }
}