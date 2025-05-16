using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class ScreeningRoomWithIdsDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid TheaterUUID { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }
}