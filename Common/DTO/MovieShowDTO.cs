using Core.Interfaces;

namespace Common.DTO;

public class MovieShowDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid MovieUUID { get; set; }

    public Guid ScreeningRoomUUID { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Price { get; set; }
}