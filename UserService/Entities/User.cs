using Core.Interfaces;

namespace UserService.Entities;

public class User : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}