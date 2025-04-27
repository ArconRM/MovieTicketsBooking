using AutoMapper;
using Common.DTO;
using Common.DTO.MovieData;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

[Route("api/[controller]")]
public class ActorController : Controller
{
    private readonly ILogger<ActorController> _logger;

    private readonly IMapper _mapper;

    private readonly IActorService _service;

    public ActorController(ILogger<ActorController> logger, IMapper mapper, IActorService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetActor))]
    public async Task<IActionResult> GetActor(Guid id, CancellationToken token)
    {
        try
        {
            var actor = await _service.GetAsync(id, token);
            var actorDTO = _mapper.Map<Actor, ActorDTO>(actor);
            return Ok(actorDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllActors))]
    public async Task<IActionResult> GetAllActors(CancellationToken token)
    {
        try
        {
            var actors = await _service.GetAllAsync(token);
            var actorsDTO = _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorDTO>>(actors);
            return Ok(actorsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteActor))]
    public async Task<IActionResult> DeleteActor(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateActor))]
    public async Task<IActionResult> CreateActor([FromBody] ActorDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ActorDTO, Actor>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Actor, ActorDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateActor))]
    public async Task<IActionResult> UpdateActor([FromBody] ActorDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ActorDTO, Actor>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Actor, ActorDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}