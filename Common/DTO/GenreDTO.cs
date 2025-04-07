using Core.Interfaces;

namespace Common.DTO;

public class GenreDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Name { get; set; }
}