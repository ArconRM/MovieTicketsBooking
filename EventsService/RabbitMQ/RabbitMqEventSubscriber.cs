using System.Text;
using EventsService.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventsService.RabbitMQ;

public class RabbitMqEventSubscriber : IEventSubscriber, IAsyncDisposable
{
    private readonly IConnection _connection;
    private IChannel _channel;

    public RabbitMqEventSubscriber(IConnection connection)
    {
        _connection = connection;
    }

    public async Task InitializeAsync(CancellationToken token)
    {
        _channel = await _connection.CreateChannelAsync(cancellationToken: token);
        await _channel.ExchangeDeclareAsync("app.events", ExchangeType.Topic, durable: true, cancellationToken: token);
    }

    public async Task SubscribeAsync<T>(
        string queueName,
        string routingKey,
        Func<T, Task> handler,
        CancellationToken token)
    {
        await _channel.QueueDeclareAsync(queueName, true, false, false, cancellationToken: token);
        await _channel.QueueBindAsync(queueName, "app.events", routingKey, cancellationToken: token);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            var @event = JsonConvert.DeserializeObject<T>(body);
            await handler(@event);
        };

        await _channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer, cancellationToken: token);
    }

    public async ValueTask DisposeAsync()
    {
        await _channel.CloseAsync();
        await _channel.DisposeAsync();
    }
}

// public Task SubscribeAsync<T>(string queueName, string routingKey, Func<T, Task> handler)
// {
//     // Declare and bind queue just once:
//     _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
//     _channel.QueueBind(queueName, "app.events", routingKey);
//
//     var consumer = new AsyncEventingBasicConsumer(_channel);
//     consumer.Received += async (_, ea) =>
//     {
//         var body = Encoding.UTF8.GetString(ea.Body.ToArray());
//         var @event = JsonConvert.DeserializeObject<T>(body);
//         try
//         {
//             await handler(@event);
//             _channel.BasicAck(ea.DeliveryTag, multiple: false);
//         }
//         catch
//         {
//             // optionally BasicNack and requeue or dead-letter
//             _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
//         }
//     };
//
//     _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
//     return Task.CompletedTask;
// }