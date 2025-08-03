using Core.Interfaces;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Service.Interfaces;

public interface ISeatService : IService<Seat>
{
    Task<IEnumerable<Seat>> GetAvailableSeatsByMovieShowUuid(Guid movieShowUuid, CancellationToken token);
}