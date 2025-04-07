using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class TheaterRepository : BaseRepository<Theater>, ITheaterRepository
{
    private readonly MovieTicketsContext _context;

    public TheaterRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }
}