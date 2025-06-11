using EventsService.Events;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.EventHandling;

public class UserSuspendedOrBannedEventHandler
{
    private readonly IBookingService _bookingService;

    public UserSuspendedOrBannedEventHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task HandleAsync(UserSuspendedOrBannedEvent @event, CancellationToken token)
    {
        Console.WriteLine($"FUCK {@event.UserUUID}");
        var userBookings = await _bookingService.GetByUserUUIDAsync(@event.UserUUID, token);
        Console.WriteLine(userBookings.Count());
        foreach (var booking in userBookings)
        {
            Console.WriteLine(booking.UUID);
        }
    }
}