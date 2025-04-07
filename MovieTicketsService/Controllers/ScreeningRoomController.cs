using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Controllers;

public class ScreeningRoomController : Controller
{
    private readonly ILogger<ScreeningRoomController> _logger;

    private readonly IMapper _mapper;

    private readonly IScreeningRoomService _service;

    public ScreeningRoomController(ILogger<ScreeningRoomController> logger, IMapper mapper,
        IScreeningRoomService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetScreeningRoom))]
    public async Task<IActionResult> GetScreeningRoom(Guid id, CancellationToken token)
    {
        try
        {
            var screeningRoom = await _service.GetAsync(id, token);
            var screeningRoomDTO = _mapper.Map<ScreeningRoom, ScreeningRoomDTO>(screeningRoom);
            return Ok(screeningRoomDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllScreeningRooms))]
    public async Task<IActionResult> GetAllScreeningRooms(CancellationToken token)
    {
        try
        {
            var screeningRooms = await _service.GetAllAsync(token);
            var screeningRoomsDTO =
                _mapper.Map<IEnumerable<ScreeningRoom>, IEnumerable<ScreeningRoomDTO>>(screeningRooms);
            return Ok(screeningRoomsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteScreeningRoom))]
    public async Task<IActionResult> DeleteScreeningRoom(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateScreeningRoom))]
    public async Task<IActionResult> CreateScreeningRoom([FromBody] ScreeningRoomDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ScreeningRoomDTO, ScreeningRoom>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<ScreeningRoom, ScreeningRoomDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateScreeningRoom))]
    public async Task<IActionResult> UpdateScreeningRoom([FromBody] ScreeningRoomDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ScreeningRoomDTO, ScreeningRoom>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<ScreeningRoom, ScreeningRoomDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}