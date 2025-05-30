using Common.Enums;
using Common.Protos;
using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class BookingService : BaseService<Booking>, IBookingService
{
    private readonly IRepository<Booking> _repository;

    private readonly UserService.UserServiceClient _userServiceClient;

    public BookingService(IRepository<Booking> repository, UserService.UserServiceClient userServiceClient) :
        base(repository)
    {
        _repository = repository;
        _userServiceClient = userServiceClient;
    }

    public async Task<Booking> CreateAsync(Booking entity, CancellationToken token)
    {
        GetUserStatusResponse response = await _userServiceClient.GetUserStatusAsync(new GetUserStatusRequest()
            { UserId = entity.UserUUID.ToString() });
        UserStatus userStatus = (UserStatus)response.Status;
        return await _repository.CreateAsync(entity, token);
    }
}