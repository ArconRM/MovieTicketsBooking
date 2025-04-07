using Core.BaseEntities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    private readonly MovieDataContext _context;

    public PersonRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }
}