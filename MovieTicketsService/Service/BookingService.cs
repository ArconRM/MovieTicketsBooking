using Common.Enums;
using Common.Protos;
using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Repository.Interfaces;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class BookingService : BaseService<Booking>, IBookingService
{
    private readonly IBookingRepository _repository;

    private readonly UserService.UserServiceClient _userServiceClient;

    public BookingService(IBookingRepository repository, UserService.UserServiceClient userServiceClient) :
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
        switch (userStatus)
        {
            case UserStatus.Banned:
            case UserStatus.Suspended:
                throw new InvalidOperationException("User is not allowed to create bookings.");

            case UserStatus.Inactive:
            case UserStatus.Active:
                break;

            case UserStatus.New:
            case UserStatus.Vip:
                entity.TotalPrice *= 0.8;
                break;
        }

        return await _repository.CreateAsync(entity, token);
    }

    public async Task<IEnumerable<Booking>> GetByUserUUIDAsync(Guid clientUUID, CancellationToken token)
    {
        return await _repository.GetByUserUUIDAsync(clientUUID, token);
    }
}