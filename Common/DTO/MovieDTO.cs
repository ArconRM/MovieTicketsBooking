using Core.Interfaces;

namespace Common.DTO;

public class MovieDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public List<Guid> GenresUUIDs { get; set; }

    public Guid ProducerUUID { get; set; }

    public List<Guid> CastUUIDs { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}