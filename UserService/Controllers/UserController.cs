using AutoMapper;
using Common.DTO;
using Common.DTO.User;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Service.Interfaces;

namespace UserService.Controllers;

[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private readonly IMapper _mapper;

    private readonly IUserService _service;

    public UserController(ILogger<UserController> logger, IMapper mapper, IUserService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetUser))]
    public async Task<IActionResult> GetUser(Guid id, CancellationToken token)
    {
        try
        {
            var user = await _service.GetAsync(id, token);
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers(CancellationToken token)
    {
        try
        {
            var users = await _service.GetAllAsync(token);
            var usersDTO = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(usersDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken token)
    {
        try
        {
            await _service.DeleteAsync(id, token);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost(nameof(CreateUser))]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<UserDTO, User>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<User, UserDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateUser))]
    public async Task<IActionResult> UpdateUser([FromBody] UserDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<UserDTO, User>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<User, UserDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}