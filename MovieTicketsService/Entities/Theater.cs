using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class Theater : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public string ContactInfo { get; set; }
}