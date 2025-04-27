using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class ScreeningRoom : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid TheaterUUID { get; set; }

    public Theater Theater { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public List<Seat> Seats { get; set; }
}