using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace MovieDataService.Entities;

public class Movie : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Guid ProducerUUID { get; set; }
}