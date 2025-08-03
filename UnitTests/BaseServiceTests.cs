using Common.Enums;
using Core.BaseEntities;
using Core.Interfaces;
using Moq;
using UserService.Entities;

namespace UnitTests;

public class BaseServiceTests
{
    private readonly Mock<IRepository<User>> _baseRepositoryMock = new();
    private readonly BaseService<User> _baseService;

    public BaseServiceTests()
    {
        _baseService = new BaseService<User>(_baseRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddEntity()
    {
        // Arrange
        var uuid = Guid.NewGuid();
        var user = new User()
        {
            UUID = uuid,
            Email = "qwerty@mail.com",
            FullName = "Test User",
            PhoneNumber = "+78005553535",
            Status = UserStatus.New
        };

        _baseRepositoryMock
            .Setup(r => r.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User u, CancellationToken _) => u);

        // Act
        var result = await _baseService.CreateAsync(user, CancellationToken.None);

        // Assert
        _baseRepositoryMock.Verify(r => r.CreateAsync(user, CancellationToken.None), Times.Once);

        Assert.Equal(uuid, result.UUID);
        Assert.Equal(user.Email, result.Email);
        Assert.Equal(user.FullName, result.FullName);
        Assert.Equal(user.PhoneNumber, result.PhoneNumber);
        Assert.Equal(UserStatus.New, result.Status);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnEntity()
    {
        // Arrange
        var uuid = Guid.NewGuid();
        var expectedUser = new User
        {
            UUID = uuid,
            Email = "get@mail.com",
            FullName = "Get User",
            PhoneNumber = "+71234567890",
            Status = UserStatus.Active
        };

        _baseRepositoryMock
            .Setup(r => r.GetAsync(uuid, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUser);

        // Act
        var result = await _baseService.GetAsync(uuid, CancellationToken.None);

        // Assert
        _baseRepositoryMock.Verify(r => r.GetAsync(uuid, CancellationToken.None), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(expectedUser.UUID, result.UUID);
        Assert.Equal(expectedUser.Email, result.Email);
        Assert.Equal(expectedUser.FullName, result.FullName);
        Assert.Equal(expectedUser.PhoneNumber, result.PhoneNumber);
        Assert.Equal(expectedUser.Status, result.Status);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntity()
    {
        // Arrange
        var uuid = Guid.NewGuid();

        _baseRepositoryMock
            .Setup(r => r.DeleteAsync(uuid, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        await _baseService.DeleteAsync(uuid, CancellationToken.None);

        // Assert
        _baseRepositoryMock.Verify(r => r.DeleteAsync(uuid, CancellationToken.None), Times.Once);
    }
}