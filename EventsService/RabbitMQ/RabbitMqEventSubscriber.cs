using System.Text;
using EventsService.Entities;
using EventsService.Interfaces;
using EventsService.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventsService.RabbitMQ;

public class RabbitMqEventSubscriber : IEventSubscriber
{
    private readonly IRabbitMqConnectionProvider _provider;

    public RabbitMqEventSubscriber(IRabbitMqConnectionProvider provider)
    {
        _provider = provider;
    }

    public async Task SubscribeAsync<T>(
        string queueName,
        string routingKey,
        Func<T, CancellationToken, Task> handler,
        CancellationToken token)
    {
        var connection = await _provider.GetConnectionAsync(token);
        var channel = await connection.CreateChannelAsync(cancellationToken: token);

        await channel.ExchangeDeclareAsync(RabbitMqExchangeNames.AppEvents, ExchangeType.Topic, durable: true,
            cancellationToken: token);
        await channel.QueueDeclareAsync(queueName, true, false, false, cancellationToken: token);
        await channel.QueueBindAsync(queueName, RabbitMqExchangeNames.AppEvents, routingKey, cancellationToken: token);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            var @event = JsonConvert.DeserializeObject<T>(body);
            await handler(@event, token);
        };

        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer, cancellationToken: token);
    }
}