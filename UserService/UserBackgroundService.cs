using EventsService.Entities;
using EventsService.Events;
using EventsService.Interfaces;
using UserService.EventHandlers;

namespace UserService;

public class UserBackgroundService : BackgroundService
{
    private readonly IEventSubscriber _subscriber;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserBackgroundService(IEventSubscriber subscriber,
        IServiceScopeFactory serviceScopeFactory)
    {
        _subscriber = subscriber;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        var provider = scope.ServiceProvider;
        var bookingAbandonedEventHandler = provider.GetRequiredService<BookingAbandonedEventHandler>();

        await _subscriber.SubscribeAsync<BookingAbandonedEvent>(
            queueName: $"notification.{RabbitMqRoutingKeys.BookingAbandoned.Value}",
            routingKey: RabbitMqRoutingKeys.BookingAbandoned.Value,
            handler: bookingAbandonedEventHandler.HandleAsync,
            token
        );
    }
}