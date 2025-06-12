using Common.Enums;
using EventsService.Events;
using EventsService.Interfaces;
using UserService.Service.Interfaces;

namespace UserService.EventHandlers;

public class BookingAbandonedEventHandler : IEventHandler<BookingAbandonedEvent>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BookingAbandonedEventHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task HandleAsync(BookingAbandonedEvent @event, CancellationToken token)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        var prodiver = scope.ServiceProvider;
        var userService = prodiver.GetRequiredService<IUserService>();

        Console.WriteLine($"{@event.BookingUUID} was abandoned");
        var user = await userService.GetAsync(@event.UserUUID, token);
        if (user.Status is not UserStatus.Banned and not UserStatus.Suspended)
        {
            user.Status = UserStatus.Suspended;
            await userService.UpdateAsync(user, token);
            Console.WriteLine($"{user.UUID} is suspended");
        }
    }
}