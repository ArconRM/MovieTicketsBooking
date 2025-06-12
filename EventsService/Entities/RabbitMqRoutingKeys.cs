namespace EventsService.Entities;

public sealed class RabbitMqRoutingKeys
{
    public static readonly RabbitMqRoutingKeys UserSuspendedOrBanned = new("user.suspended-or-banned");
    public static readonly RabbitMqRoutingKeys BookingAbandoned = new("booking.abandoned");
    public string Value { get; }

    private RabbitMqRoutingKeys(string value)
    {
        Value = value;
    }

    public override bool Equals(object? obj) => obj is RabbitMqRoutingKeys other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}