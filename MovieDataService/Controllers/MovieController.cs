using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

// TODO: убрать async из названия
// TODO: интерфейсом резулта
[Route("api/[controller]")]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    private readonly IMapper _mapper;

    private readonly IMovieService _service;

    public MovieController(ILogger<MovieController> logger, IMapper mapper, IMovieService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet("GetMovie")]
    public async Task<ActionResult> GetMovieAsync(Guid id)
    {
        try
        {
            var movie = await _service.GetAsync(id);
            var movieDTO = _mapper.Map<Movie, MovieDTO>(movie);
            return Ok(movieDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet("GetAllMovies")]
    public async Task<ActionResult> GetAllMoviesAsync()
    {
        try
        {
            var movies = await _service.GetAllAsync();
            var moviesDTO = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
            return Ok(moviesDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("DeleteMovie")]
    public async Task<ActionResult> DeleteMovieAsync(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost("CreateMovie")]
    public async Task<ActionResult> CreateMovieAsync([FromBody] MovieDTO entityDTO)
    {
        try
        {
            var entity = _mapper.Map<MovieDTO, Movie>(entityDTO);
            var newEntity = await _service.CreateAsync(entity);
            var newEntityDTO = _mapper.Map<Movie, MovieDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch("UpdateMovie")]
    public async Task<ActionResult> UpdateMovieAsync([FromBody] MovieDTO entityDTO)
    {
        try
        {
            var entity = _mapper.Map<MovieDTO, Movie>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity);
            var updatedEntityDTO = _mapper.Map<Movie, MovieDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}