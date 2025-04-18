using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;
using MovieDataService.Repository.Interfaces;

namespace MovieDataService.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieDataContext _context;

    public MovieRepository(MovieDataContext context) : base(context)
    {
        _context = context;
    }
}