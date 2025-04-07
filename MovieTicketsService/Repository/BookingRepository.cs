using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class BookingRepository : BaseRepository<Booking>, IBookingRepository
{
    private readonly MovieTicketsContext _context;

    public BookingRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }
}