using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieContext _context;

    public MovieRepository(MovieContext context) : base(context)
    {
        _context = context;
    }
}