using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class MovieShowFullDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public ScreeningRoomWithIdsDTO ScreeningRoom { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Price { get; set; }
}