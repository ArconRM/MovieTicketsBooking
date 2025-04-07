using Core.BaseEntities;
using Core.Interfaces;
using UserService.Entities;
using UserService.Service.Interfaces;

namespace UserService.Service;

public class UserService : BaseService<User>, IUserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository) : base(repository)
    {
        _repository = repository;
    }
}