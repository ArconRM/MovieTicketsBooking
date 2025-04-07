using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class SeatRepository : BaseRepository<Seat>, ISeatRepository
{
    private readonly MovieTicketsContext _context;

    public SeatRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }
}