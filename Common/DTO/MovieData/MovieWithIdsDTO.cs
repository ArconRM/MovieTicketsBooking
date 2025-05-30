namespace Common.DTO.MovieData;

public class MovieWithIdsDTO
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public List<Guid> GenresUUIDs { get; set; }

    public Guid ProducerUUID { get; set; }

    public List<Guid> ActorsUUIDs { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}