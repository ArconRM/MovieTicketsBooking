using EventsService.Events;

namespace MovieTicketsService.EventHandling;

public class UserSuspendedOrBannedEventHandler
{
    public Task Handle(UserSuspendedOrBannedEvent @event)
    {
        Console.WriteLine($"FUCK {@event.UserUUID}");
        return Task.CompletedTask;
    }
}