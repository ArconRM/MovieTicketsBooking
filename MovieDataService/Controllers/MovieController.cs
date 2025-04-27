using AutoMapper;
using Common.DTO;
using Common.DTO.MovieData;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

[Route("api/[controller]")]
public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;

    private readonly IMapper _mapper;

    private readonly IMovieService _movieService;

    private readonly IFromFileEntitySaverService _fromFileEntitySaverService;

    public MovieController(
        ILogger<MovieController> logger,
        IMapper mapper,
        IMovieService movieService,
        IFromFileEntitySaverService fromFileEntitySaverService
    )
    {
        _logger = logger;
        _mapper = mapper;
        _movieService = movieService;
        _fromFileEntitySaverService = fromFileEntitySaverService;
    }

    // Сам подставит токен
    // Еще можно так HttpContext.RequestAborted.IsCancellationRequested
    [HttpGet(nameof(GetMovie))]
    public async Task<IActionResult> GetMovie(Guid id, CancellationToken token)
    {
        try
        {
            var movie = await _movieService.GetAsync(id, token);
            var movieDTO = _mapper.Map<Movie, MovieFullDTO>(movie);
            return Ok(movieDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetMoviesByGenre))]
    public async Task<IActionResult> GetMoviesByGenre(Guid genreId, CancellationToken token)
    {
        try
        {
            var movies = await _movieService.GetMoviesByGenreAsync(genreId, token);
            var moviesDTO = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDisplayDTO>>(movies);
            return Ok(moviesDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllMovies))]
    public async Task<IActionResult> GetAllMovies(CancellationToken token)
    {
        try
        {
            var movies = await _movieService.GetAllAsync(token);
            var moviesDTO = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDisplayDTO>>(movies);
            return Ok(moviesDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteMovie))]
    public async Task<IActionResult> DeleteMovie(Guid id, CancellationToken token)
    {
        try
        {
            await _movieService.DeleteAsync(id, token);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost(nameof(CreateMovie))]
    public async Task<IActionResult> CreateMovie([FromBody] MovieWithIdsDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieWithIdsDTO, Movie>(entityDTO);
            var newEntity = await _movieService.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Movie, MovieWithIdsDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateMovie))]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieFullDTO entityDisplayDto, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieFullDTO, Movie>(entityDisplayDto);
            var updatedEntity = await _movieService.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Movie, MovieFullDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost(nameof(LoadMoviesFromFile))]
    public async Task<IActionResult> LoadMoviesFromFile(IFormFile file, CancellationToken token)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var stream = file.OpenReadStream();
            var movies = await _fromFileEntitySaverService.SaveFromStreamAsync(stream, token);
            return Ok(movies);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}