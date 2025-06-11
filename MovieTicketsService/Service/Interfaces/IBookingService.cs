using Core.Interfaces;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Service.Interfaces;

public interface IBookingService : IService<Booking>
{
    Task<IEnumerable<Booking>> GetByUserUUIDAsync(Guid clientUUID, CancellationToken token);
}