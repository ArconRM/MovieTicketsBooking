using System.Text;
using EventsService.Entities;
using EventsService.Interfaces;
using EventsService.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventsService.RabbitMQ;

public class RabbitMqEventPublisher : IEventPublisher
{
    private readonly IRabbitMqConnectionProvider _provider;

    public RabbitMqEventPublisher(IRabbitMqConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task PublishAsync<T>(T @event, string routingKey, CancellationToken token)
    {
        var connection = await _provider.GetConnectionAsync(token);
        await using var channel = await connection.CreateChannelAsync(cancellationToken: token);

        await channel.ExchangeDeclareAsync(RabbitMqExchangeNames.AppEvents, ExchangeType.Topic, durable: true,
            cancellationToken: token);

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

        await channel.BasicPublishAsync(RabbitMqExchangeNames.AppEvents, routingKey, body, cancellationToken: token);
    }
}