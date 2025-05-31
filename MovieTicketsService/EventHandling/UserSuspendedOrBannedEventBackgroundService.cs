using EventsService.Events;
using EventsService.Interfaces;

namespace MovieTicketsService.EventHandling;

public class UserSuspendedOrBannedEventBackgroundService : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly UserSuspendedOrBannedEventHandler _handler;

    public UserSuspendedOrBannedEventBackgroundService(IEventSubscriber subscriber,
        UserSuspendedOrBannedEventHandler handler)
    {
        _subscriber = subscriber;
        _handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        await _subscriber.SubscribeAsync<UserSuspendedOrBannedEvent>(
            queueName: "notification.user.suspended-or-banned",
            routingKey: "user.suspended-or-banned",
            handler: _handler.Handle,
            token
        );
    }
}