using Common.Enums;
using Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using UserService.Entities;
using UserService.Repository;

namespace IntegrationTests;

public class BaseRepositoryTests : IAsyncLifetime
{
    private UserContext _context;
    private BaseRepository<User> _repository;
    private readonly Guid _testUserUuid = Guid.NewGuid();
    private DbContextOptions<UserContext> _options;

    public async Task InitializeAsync()
    {
        _options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new UserContext(_options);
        await _context.Database.EnsureCreatedAsync();
        _repository = new BaseRepository<User>(_context);
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task CreateAsync_ShouldAddEntity()
    {
        // Arrange
        var user = new User()
        {
            UUID = _testUserUuid,
            Email = "qwerty@mail.com",
            FullName = "Test User",
            PhoneNumber = "+78005553535",
            Status = UserStatus.New
        };

        // Act
        await _repository.CreateAsync(user, CancellationToken.None);

        // Assert
        using (var assertContext = new UserContext(_options))
        {
            var result = await assertContext.Users.FindAsync(_testUserUuid);
            Assert.NotNull(result);
            Assert.Equal(_testUserUuid, result.UUID);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.FullName, result.FullName);
            Assert.Equal(user.PhoneNumber, result.PhoneNumber);
            Assert.Equal(UserStatus.New, result.Status);
        }
    }

    [Fact]
    public async Task GetAsync_ShouldRetrieveEntity()
    {
        // Arrange
        using (var arrangeContext = new UserContext(_options))
        {
            await arrangeContext.Users.AddAsync(new User
            {
                UUID = _testUserUuid,
                Email = "qwerty@mail.com",
                FullName = "Test User",
                PhoneNumber = "+78005553535",
                Status = UserStatus.New
            });
            await arrangeContext.SaveChangesAsync();
        }

        // Act
        var result = await _repository.GetAsync(_testUserUuid, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_testUserUuid, result.UUID);
        Assert.Equal("qwerty@mail.com", result.Email);
        Assert.Equal("Test User", result.FullName);
        Assert.Equal("+78005553535", result.PhoneNumber);
        Assert.Equal(UserStatus.New, result.Status);
    }

    [Fact]
    public async Task UpdateAsync_ShouldModifyEntity()
    {
        // Arrange
        using (var arrangeContext = new UserContext(_options))
        {
            await arrangeContext.Users.AddAsync(new User
            {
                UUID = _testUserUuid,
                Email = "original@mail.com",
                FullName = "Original",
                PhoneNumber = "+11111111111",
                Status = UserStatus.New
            });
            await arrangeContext.SaveChangesAsync();
        }

        var user = new User
        {
            UUID = _testUserUuid,
            Email = "updated@mail.com",
            FullName = "Updated",
            PhoneNumber = "+22222222222",
            Status = UserStatus.Active
        };

        // Act
        await _repository.UpdateAsync(user, CancellationToken.None);

        // Assert
        using (var assertContext = new UserContext(_options))
        {
            var updated = await assertContext.Users.FindAsync(_testUserUuid);
            Assert.NotNull(updated);
            Assert.Equal("updated@mail.com", updated.Email);
            Assert.Equal("Updated", updated.FullName);
            Assert.Equal("+22222222222", updated.PhoneNumber);
            Assert.Equal(UserStatus.Active, updated.Status);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntity()
    {
        // Arrange
        using (var arrangeContext = new UserContext(_options))
        {
            await arrangeContext.Users.AddAsync(new User
            {
                UUID = _testUserUuid,
                Email = "delete@mail.com",
                FullName = "To Delete",
                PhoneNumber = "+33333333333",
                Status = UserStatus.Inactive
            });
            await arrangeContext.SaveChangesAsync();
        }

        // Act
        await _repository.DeleteAsync(_testUserUuid, CancellationToken.None);

        // Assert
        using (var assertContext = new UserContext(_options))
        {
            var deleted = await assertContext.Users.FindAsync(_testUserUuid);
            Assert.Null(deleted);
        }
    }
}