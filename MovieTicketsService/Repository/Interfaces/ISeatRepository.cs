using Core.Interfaces;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository.Interfaces;

public interface ISeatRepository : IRepository<Seat>
{
    Task<IEnumerable<Seat>> GetAvailableSeatsByMovieShowUuid(Guid movieShowUuid, CancellationToken token);
}