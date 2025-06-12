namespace EventsService.Interfaces;

public interface IEventHandler<in TEvent>
{
    Task HandleAsync(TEvent @event, CancellationToken token);
}