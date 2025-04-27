using Core.Interfaces;

namespace Common.DTO.MovieData;

public class MovieFullDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public List<GenreDTO> Genres { get; set; }

    public ProducerDTO Producer { get; set; }

    public List<ActorDTO> Actors { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}