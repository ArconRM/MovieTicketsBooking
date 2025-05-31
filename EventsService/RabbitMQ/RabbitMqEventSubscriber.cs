using System.Text;
using EventsService.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventsService.RabbitMQ;

public class RabbitMqEventSubscriber : IEventSubscriber
{
    private readonly IConnection _connection;

    public RabbitMqEventSubscriber(IConnection connection)
    {
        _connection = connection;
    }

    public async Task SubscribeAsync<T>(string queueName, string routingKey, Func<T, Task> handler,
        CancellationToken token)
    {
        using var channel = await _connection.CreateChannelAsync(cancellationToken: token);
        await channel.ExchangeDeclareAsync("app.events", ExchangeType.Topic, durable: true, cancellationToken: token);
        await channel.QueueDeclareAsync(queueName, true, false, false, null, cancellationToken: token);
        await channel.QueueBindAsync(queueName, "app.events", routingKey, cancellationToken: token);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            var @event = JsonConvert.DeserializeObject<T>(body);
            await handler(@event);
        };

        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer, cancellationToken: token);
    }
}