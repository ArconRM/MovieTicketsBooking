using Core.Interfaces;

namespace Common.DTO;

public class PersonDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public DateOnly DateBirth { get; set; }

    public string Nationality { get; set; }

    public string Description { get; set; }

    public Guid? AvatarUUID { get; set; }
}