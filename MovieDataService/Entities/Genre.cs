using Core.Interfaces;

namespace MovieDataService.Entities;

public class Genre : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Name { get; set; }

    public List<Movie> Movies { get; set; }
}