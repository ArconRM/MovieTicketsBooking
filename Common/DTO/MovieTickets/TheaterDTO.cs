using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class TheaterDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public string ContactInfo { get; set; }
}