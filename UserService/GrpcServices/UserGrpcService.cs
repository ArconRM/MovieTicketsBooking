using Common.Enums;
using Common.Protos;
using Google.Protobuf.WellKnownTypes;
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

    public override async Task<GetUserStatusResponse> GetUserStatus(GetUserStatusRequest request,
        ServerCallContext context)
    {
        User user = await _userService.GetAsync(Guid.Parse(request.UserId), context.CancellationToken);
        return new GetUserStatusResponse
        {
            Status = (int)user.Status,
        };
    }

    public override async Task<Empty> UpdateUserStatus(UpdateUserStatusRequest request, ServerCallContext context)
    {
        User oldUser = await _userService.GetAsync(Guid.Parse(request.UserId), context.CancellationToken);
        oldUser.Status = (UserStatus)request.Status;
        await _userService.UpdateAsync(oldUser, context.CancellationToken);
        return new Empty();
    }
}