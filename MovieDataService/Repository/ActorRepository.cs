using Core.BaseEntities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class ActorRepository : BaseRepository<Actor>, IActorRepository
{
    private readonly MovieDataContext _context;

    public ActorRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }
}