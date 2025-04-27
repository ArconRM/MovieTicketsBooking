namespace Common.DTO.MovieData;

public class MovieWithIdsDTO
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public List<Guid> GenresIds { get; set; }

    public Guid ProducerId { get; set; }

    public List<Guid> ActorsIds { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}