using Common.Enums;
using EventsService.Events;
using EventsService.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.EventHandling;

public class UserSuspendedOrBannedEventHandler : IEventHandler<UserSuspendedOrBannedEvent>
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

        Console.WriteLine($"{@event.UserUUID} got banned");
        var userBookings = await bookingService.GetByUserUUIDAsync(@event.UserUUID, token);
        foreach (var booking in userBookings)
        {
            booking.Status = BookingStatus.Canceled;
            await bookingService.UpdateAsync(booking, token);
            Console.WriteLine($"{booking.UUID} is cancelled");
        }
    }
}