using Core.Interfaces;

namespace Common.DTO.MovieData;

public class GenreDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Name { get; set; }
}