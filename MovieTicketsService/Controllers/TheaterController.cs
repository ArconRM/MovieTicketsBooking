using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Controllers;

public class TheaterController : Controller
{
    private readonly ILogger<TheaterController> _logger;

    private readonly IMapper _mapper;

    private readonly ITheaterService _service;

    public TheaterController(ILogger<TheaterController> logger, IMapper mapper, ITheaterService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetTheater))]
    public async Task<IActionResult> GetTheater(Guid id, CancellationToken token)
    {
        try
        {
            var theater = await _service.GetAsync(id, token);
            var theaterDTO = _mapper.Map<Theater, TheaterDTO>(theater);
            return Ok(theaterDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllTheaters))]
    public async Task<IActionResult> GetAllTheaters(CancellationToken token)
    {
        try
        {
            var theaters = await _service.GetAllAsync(token);
            var theatersDTO = _mapper.Map<IEnumerable<Theater>, IEnumerable<TheaterDTO>>(theaters);
            return Ok(theatersDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteTheater))]
    public async Task<IActionResult> DeleteTheater(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateTheater))]
    public async Task<IActionResult> CreateTheater([FromBody] TheaterDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<TheaterDTO, Theater>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Theater, TheaterDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateTheater))]
    public async Task<IActionResult> UpdateTheater([FromBody] TheaterDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<TheaterDTO, Theater>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Theater, TheaterDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}