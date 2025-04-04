using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MoviesService.Entities;
using MoviesService.Services.Interfaces;

namespace MoviesService.Controllers;

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
}