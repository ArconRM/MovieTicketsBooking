using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace MovieDataService.Entities;

public class Movie : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public List<Genre> Genres { get; set; }

    public Guid ProducerId { get; set; }
    public Producer Producer { get; set; }

    public List<Actor> Actors { get; set; }

    public string? Description { get; set; }

    public double? Rating { get; set; }

    public int Duration { get; set; }

    public DateTime ReleaseDate { get; set; }
}