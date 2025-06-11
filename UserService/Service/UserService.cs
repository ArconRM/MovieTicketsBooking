using Common.Enums;
using Core.BaseEntities;
using Core.Interfaces;
using EventsService.Events;
using EventsService.Interfaces;
using UserService.Entities;
using UserService.Service.Interfaces;

namespace UserService.Service;

public class UserService : BaseService<User>, IUserService
{
    private readonly IRepository<User> _repository;
    private readonly IEventPublisher _eventPublisher;

    public UserService(IRepository<User> repository, IEventPublisher eventPublisher) : base(repository)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken token)
    {
        if (entity.Status is UserStatus.Banned or UserStatus.Suspended)
        {
            var evt = new UserSuspendedOrBannedEvent { UserUUID = entity.UUID };
            await _eventPublisher.PublishAsync(evt, "user.suspended-or-banned", token);
        }

        return await _repository.UpdateAsync(entity, token);
    }
}