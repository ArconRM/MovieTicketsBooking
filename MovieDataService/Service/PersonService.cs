using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class PersonService : BaseService<Person>, IPersonService
{
    private readonly IRepository<Person> _repository;

    public PersonService(IRepository<Person> repository) : base(repository)
    {
        _repository = repository;
    }
}