using Core.BaseEntities;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
{
    private readonly MovieDataContext _context;

    public ProducerRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }
}