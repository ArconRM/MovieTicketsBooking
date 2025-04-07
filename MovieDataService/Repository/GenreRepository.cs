using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly MovieDataContext _context;

    public GenreRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }
}