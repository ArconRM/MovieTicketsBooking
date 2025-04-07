using AutoMapper;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

[Route("api/[controller]")]
public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;

    private readonly IMapper _mapper;

    private readonly IPersonService _service;

    public PersonController(ILogger<PersonController> logger, IMapper mapper, IPersonService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetPerson))]
    public async Task<IActionResult> GetPerson(Guid id, CancellationToken token)
    {
        try
        {
            var person = await _service.GetAsync(id, token);
            var personDTO = _mapper.Map<Person, PersonDTO>(person);
            return Ok(personDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllPersons))]
    public async Task<IActionResult> GetAllPersons(CancellationToken token)
    {
        try
        {
            var persons = await _service.GetAllAsync(token);
            var personsDTO = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(persons);
            return Ok(personsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeletePerson))]
    public async Task<IActionResult> DeletePerson(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreatePerson))]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<PersonDTO, Person>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Person, PersonDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdatePerson))]
    public async Task<IActionResult> UpdatePerson([FromBody] PersonDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<PersonDTO, Person>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Person, PersonDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}