using Core.Interfaces;

namespace Common.DTO.User;

public class UserDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}