using Core.Interfaces;

namespace MovieDataService.Entities;

public class Actor : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateTime DateBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Description { get; set; }

    public Guid? AvatarUUID { get; set; }

    public List<Movie> Movies { get; set; }
}