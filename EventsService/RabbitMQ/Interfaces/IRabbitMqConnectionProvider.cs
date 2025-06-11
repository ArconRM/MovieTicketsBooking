using RabbitMQ.Client;

namespace EventsService.RabbitMQ.Interfaces;

public interface IRabbitMqConnectionProvider
{
    Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default);
}