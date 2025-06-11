namespace EventsService.Interfaces;

public interface IEventSubscriber
{
    Task InitializeAsync(CancellationToken token);
    Task SubscribeAsync<T>(string queueName, string routingKey, Func<T, Task> handler, CancellationToken token);
}