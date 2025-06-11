using EventsService.Events;
using EventsService.Interfaces;
using Grpc.Net.Client.Balancer;
using MovieTicketsService.EventHandling;

namespace MovieTicketsService;

public class MovieTicketsBackgroundService : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly IServiceProvider _serviceProvider;

    public MovieTicketsBackgroundService(IEventSubscriber subscriber,
        IServiceProvider serviceProvider)
    {
        _subscriber = subscriber;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        using var scope = _serviceProvider.CreateScope();

        var userSuspendedOrBannedEventHandler = scope.ServiceProvider
            .GetRequiredService<UserSuspendedOrBannedEventHandler>();

        await _subscriber.SubscribeAsync<UserSuspendedOrBannedEvent>(
            queueName: "notification.user.suspended-or-banned",
            routingKey: "user.suspended-or-banned",
            handler: userSuspendedOrBannedEventHandler.HandleAsync,
            token
        );
    }
}