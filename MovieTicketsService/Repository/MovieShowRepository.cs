using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class MovieShowRepository : BaseRepository<MovieShow>, IMovieShowRepository
{
    private readonly MovieTicketsContext _context;

    public MovieShowRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }
}