using Core.BaseEntities;
using Core.Interfaces;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Service;

public class GenreService : BaseService<Genre>, IGenreService
{
    private readonly IRepository<Genre> _repository;

    public GenreService(IRepository<Genre> repository) : base(repository)
    {
        _repository = repository;
    }
}