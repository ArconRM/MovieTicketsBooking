namespace EventsService.Interfaces;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event, string routingKey, CancellationToken token);
}