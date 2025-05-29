using Common;
using Common.Enums;
using UserService.Entities;

namespace UserService.Extensions;

public static class UserExtensions
{
    public static User ToEntityUser(this Common.Protos.User grpcUser)
    {
        User user = new User()
        {
            UUID = Guid.Parse(grpcUser.Uuid),
            FullName = grpcUser.FullName,
            Email = grpcUser.Email,
            Status = (UserStatus)grpcUser.Status
        };
        return user;
    }

    public static Common.Protos.User ToGrpcUser(this User entityUser)
    {
        Common.Protos.User user = new Common.Protos.User()
        {
            Uuid = entityUser.UUID.ToString(),
            FullName = entityUser.FullName,
            Email = entityUser.Email,
            Status = (int)entityUser.Status
        };
        return user;
    }
}