using EventsService.Events;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.EventHandling;

public class UserSuspendedOrBannedEventHandler
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserSuspendedOrBannedEventHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task HandleAsync(UserSuspendedOrBannedEvent @event, CancellationToken token)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        var prodiver = scope.ServiceProvider;
        var bookingService = prodiver.GetRequiredService<IBookingService>();

        Console.WriteLine($"FUCK {@event.UserUUID}");
        var userBookings = await bookingService.GetByUserUUIDAsync(@event.UserUUID, token);
        Console.WriteLine(userBookings.Count());
        foreach (var booking in userBookings)
        {
            Console.WriteLine(booking.UUID);
        }
    }
}