using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class ScreeningRoomFullDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public TheaterDTO Theater { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }
}