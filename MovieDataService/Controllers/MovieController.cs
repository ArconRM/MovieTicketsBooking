using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

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

    // Сам подставит токен
    // Еще можно так HttpContext.RequestAborted.IsCancellationRequested
    [HttpGet(nameof(GetMovie))]
    public async Task<IActionResult> GetMovie(Guid id, CancellationToken token)
    {
        try
        {
            var movie = await _service.GetAsync(id, token);
            var movieDTO = _mapper.Map<Movie, MovieDTO>(movie);
            return Ok(movieDTO);
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
            var movies = await _service.GetAllAsync(token);
            var moviesDTO = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
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
            await _service.DeleteAsync(id, token);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpPost(nameof(CreateMovie))]
    public async Task<IActionResult> CreateMovie([FromBody] MovieDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieDTO, Movie>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Movie, MovieDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateMovie))]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<MovieDTO, Movie>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Movie, MovieDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    // [HttpPost]
    // public async Task<IActionResult> AddFile(IFormFile uploadedFile)
    // {
    //     if (uploadedFile != null)
    //     {
    //         // путь к папке Files
    //         string path = "/Files/" + uploadedFile.FileName;
    //         // сохраняем файл в папку Files в каталоге wwwroot
    //         using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
    //         {
    //             await uploadedFile.CopyToAsync(fileStream);
    //         }
    //         FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
    //         _context.Files.Add(file);
    //         _context.SaveChanges();
    //     }
    // }
}