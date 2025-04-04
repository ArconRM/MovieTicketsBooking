using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MoviesService.Entities;
using MoviesService.Repository.Interfaces;

namespace MoviesService.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly MovieContext _context;

    public MovieRepository(MovieContext context) : base(context)
    {
        _context = context;
    }
}