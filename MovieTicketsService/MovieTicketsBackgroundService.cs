using EventsService.Events;
using EventsService.Interfaces;
using Grpc.Net.Client.Balancer;
using MovieTicketsService.EventHandling;

namespace MovieTicketsService;

public class MovieTicketsBackgroundService : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly UserSuspendedOrBannedEventHandler _userSuspendedOrBannedEventHandler;

    public MovieTicketsBackgroundService(IEventSubscriber subscriber,
        UserSuspendedOrBannedEventHandler userSuspendedOrBannedEventHandler)
    {
        _subscriber = subscriber;
        _userSuspendedOrBannedEventHandler = userSuspendedOrBannedEventHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        // await _subscriber.InitializeAsync(token);

        await _subscriber.SubscribeAsync<UserSuspendedOrBannedEvent>(
            queueName: "notification.user.suspended-or-banned",
            routingKey: "user.suspended-or-banned",
            handler: _userSuspendedOrBannedEventHandler.Handle,
            token
        );
    }
}