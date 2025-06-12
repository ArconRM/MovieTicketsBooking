using EventsService.Entities;
using EventsService.Events;
using EventsService.Interfaces;
using Grpc.Net.Client.Balancer;
using MovieTicketsService.EventHandling;

namespace MovieTicketsService;

public class MovieTicketsBackgroundService : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MovieTicketsBackgroundService(IEventSubscriber subscriber,
        IServiceScopeFactory serviceScopeFactory)
    {
        _subscriber = subscriber;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        var provider = scope.ServiceProvider;
        var userSuspendedOrBannedEventHandler = provider.GetRequiredService<UserSuspendedOrBannedEventHandler>();

        await _subscriber.SubscribeAsync<UserSuspendedOrBannedEvent>(
            queueName: $"notification.{RabbitMqRoutingKeys.UserSuspendedOrBanned.Value}",
            routingKey: RabbitMqRoutingKeys.UserSuspendedOrBanned.Value,
            handler: userSuspendedOrBannedEventHandler.HandleAsync,
            token
        );
    }
}