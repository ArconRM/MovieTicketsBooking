using AutoMapper;
using Common.DTO;
using Common.DTO.MovieTickets;
using Microsoft.AspNetCore.Mvc;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Controllers;

public class SeatController : Controller
{
    private readonly ILogger<SeatController> _logger;

    private readonly IMapper _mapper;

    private readonly ISeatService _service;

    public SeatController(ILogger<SeatController> logger, IMapper mapper, ISeatService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetSeat))]
    public async Task<IActionResult> GetSeat(Guid id, CancellationToken token)
    {
        try
        {
            var seat = await _service.GetAsync(id, token);
            var seatDTO = _mapper.Map<Seat, SeatFullDTO>(seat);
            return Ok(seatDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllSeats))]
    public async Task<IActionResult> GetAllSeats(CancellationToken token)
    {
        try
        {
            var seats = await _service.GetAllAsync(token);
            var seatsDTO = _mapper.Map<IEnumerable<Seat>, IEnumerable<SeatWithIdsDTO>>(seats);
            return Ok(seatsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteSeat))]
    public async Task<IActionResult> DeleteSeat(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateSeat))]
    public async Task<IActionResult> CreateSeat([FromBody] SeatWithIdsDTO entityWithIdsDto, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<SeatWithIdsDTO, Seat>(entityWithIdsDto);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Seat, SeatWithIdsDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateSeat))]
    public async Task<IActionResult> UpdateSeat([FromBody] SeatWithIdsDTO entityWithIdsDto, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<SeatWithIdsDTO, Seat>(entityWithIdsDto);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Seat, SeatWithIdsDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}