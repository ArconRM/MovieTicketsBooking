using Core.Interfaces;

namespace MovieDataService.Entities;

public class Person : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateOnly DateBirth { get; set; }

    public string Description { get; set; }

    public Guid AvatarUUID { get; set; }
}