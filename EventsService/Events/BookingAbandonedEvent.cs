namespace EventsService.Events;

public class BookingAbandonedEvent
{
    public Guid BookingUUID { get; set; }

    public Guid UserUUID { get; set; }
}