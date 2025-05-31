using System.Text;
using EventsService.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventsService.RabbitMQ;

public class RabbitMqEventPublisher : IEventPublisher
{
    private readonly IConnection _connection;

    public RabbitMqEventPublisher(IConnection connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync<T>(T @event, string routingKey, CancellationToken token)
    {
        using IChannel channel = await _connection.CreateChannelAsync(cancellationToken: token);
        await channel.ExchangeDeclareAsync("app.events", ExchangeType.Topic, durable: true, cancellationToken: token);

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        await channel.BasicPublishAsync("app.events", routingKey, body, cancellationToken: token);
    }
}