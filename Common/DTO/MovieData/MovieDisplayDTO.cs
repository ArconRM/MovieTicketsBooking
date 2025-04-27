using Core.Interfaces;

namespace Common.DTO.MovieData;

public class MovieDisplayDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}