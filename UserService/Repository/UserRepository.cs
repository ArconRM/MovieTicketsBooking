using Core.BaseEntities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using UserService.Entities;
using UserService.Repository.Interfaces;

namespace UserService.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context) : base(context)
    {
        _context = context;
    }
}