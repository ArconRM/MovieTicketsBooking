using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Controllers;

public class MovieShowController : Controller
{
    private readonly ILogger<MovieShowController> _logger;

    private readonly IMapper _mapper;

    private readonly IMovieShowService _service;

    public MovieShowController(ILogger<MovieShowController> logger, IMapper mapper, IMovieShowService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetMovieShow))]
    public async Task<IActionResult> GetMovieShow(Guid id, CancellationToken token)
    {
        try
        {
            var movieShow = await _service.GetAsync(id, token);
            var movieShowDTO = _mapper.Map<MovieShow, MovieShowDTO>(movieShow);
            return Ok(movieShowDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllMovieShows))]
    public async Task<IActionResult> GetAllMovieShows(CancellationToken token)
    {
        try
        {
            var movieShows = await _service.GetAllAsync(token);
            var movieShowsDTO = _mapper.Map<IEnumerable<MovieShow>, IEnumerable<MovieShowDTO>>(movieShows);
            return Ok(movieShowsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteMovieShow))]
    public async Task<IActionResult> DeleteMovieShow(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateMovieShow))]
    public async Task<IActionResult> CreateMovieShow([FromBody] MovieShowDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieShowDTO, MovieShow>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<MovieShow, MovieShowDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateMovieShow))]
    public async Task<IActionResult> UpdateMovieShow([FromBody] MovieShowDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieShowDTO, MovieShow>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<MovieShow, MovieShowDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}