using Core.Interfaces;

namespace Common.DTO.MovieData;

public class ProducerDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateTime DateBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Description { get; set; }

    public Guid? AvatarUUID { get; set; }
}