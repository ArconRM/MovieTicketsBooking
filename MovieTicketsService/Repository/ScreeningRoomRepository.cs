using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;

namespace MovieTicketsService.Repository;

public class ScreeningRoomRepository : BaseRepository<ScreeningRoom>, IScreeningRoomRepository
{
    private readonly MovieTicketsContext _context;

    public ScreeningRoomRepository(MovieTicketsContext context) : base(context)
    {
        _context = context;
    }
}