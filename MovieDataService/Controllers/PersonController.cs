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

    [HttpGet("GetPerson")]
    public async Task<ActionResult> GetPersonAsync(Guid id)
    {
        try
        {
            var person = await _service.GetAsync(id);
            var personDTO = _mapper.Map<Person, PersonDTO>(person);
            return Ok(personDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet("GetAllPersons")]
    public async Task<ActionResult> GetAllPersonsAsync()
    {
        try
        {
            var persons = await _service.GetAllAsync();
            var personsDTO = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(persons);
            return Ok(personsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("DeletePerson")]
    public async Task<ActionResult> DeletePersonAsync(Guid id)
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

    [HttpPost("CreatePerson")]
    public async Task<ActionResult> CreatePersonAsync([FromBody] PersonDTO entityDTO)
    {
        try
        {
            var entity = _mapper.Map<PersonDTO, Person>(entityDTO);
            var newEntity = await _service.CreateAsync(entity);
            var newEntityDTO = _mapper.Map<Person, PersonDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch("UpdatePerson")]
    public async Task<ActionResult> UpdatePersonAsync([FromBody] PersonDTO entityDTO)
    {
        try
        {
            var entity = _mapper.Map<PersonDTO, Person>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity);
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