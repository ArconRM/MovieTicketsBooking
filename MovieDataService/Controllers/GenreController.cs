using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

public class GenreController : Controller
{
    private readonly ILogger<PersonController> _logger;

    private readonly IMapper _mapper;

    private readonly IGenreService _service;

    public GenreController(ILogger<PersonController> logger, IMapper mapper, IGenreService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetGenre))]
    public async Task<IActionResult> GetGenre(Guid id, CancellationToken token)
    {
        try
        {
            var genre = await _service.GetAsync(id, token);
            var genreDTO = _mapper.Map<Genre, GenreDTO>(genre);
            return Ok(genreDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllGenres))]
    public async Task<IActionResult> GetAllGenres(CancellationToken token)
    {
        try
        {
            var genres = await _service.GetAllAsync(token);
            var genresDTO = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(genres);
            return Ok(genresDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteGenre))]
    public async Task<IActionResult> DeleteGenre(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateGenre))]
    public async Task<IActionResult> CreateGenre([FromBody] GenreDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<GenreDTO, Genre>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Genre, GenreDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateGenre))]
    public async Task<IActionResult> UpdateGenre([FromBody] GenreDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<GenreDTO, Genre>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Genre, GenreDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}