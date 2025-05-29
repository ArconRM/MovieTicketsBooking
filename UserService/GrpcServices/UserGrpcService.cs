using Grpc.Core;
using UserService.Entities;
using UserService.Extensions;
using UserService.Service.Interfaces;

namespace UserService.GrpcServices;

public class UserGrpcService : Common.Protos.UserService.UserServiceBase
{
    private readonly IUserService _userService;

    public UserGrpcService(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task<Common.Protos.User> GetById(Common.Protos.UuidQuery request, ServerCallContext context)
    {
        User user = await _userService.GetAsync(Guid.Parse(request.Uuid), context.CancellationToken);
        return user.ToGrpcUser();
    }
}