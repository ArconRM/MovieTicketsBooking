using AutoMapper;
using Common.DTO.MovieData;
using Microsoft.AspNetCore.Mvc;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;

namespace MovieDataService.Controllers;

[Route("api/[controller]")]
public class ProducerController : Controller
{
    private readonly ILogger<ProducerController> _logger;

    private readonly IMapper _mapper;

    private readonly IProducerService _service;

    public ProducerController(ILogger<ProducerController> logger, IMapper mapper, IProducerService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetProducer))]
    public async Task<IActionResult> GetProducer(Guid id, CancellationToken token)
    {
        try
        {
            var producer = await _service.GetAsync(id, token);
            var producerDTO = _mapper.Map<Producer, ProducerDTO>(producer);
            return Ok(producerDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllProducers))]
    public async Task<IActionResult> GetAllProducers(CancellationToken token)
    {
        try
        {
            var producers = await _service.GetAllAsync(token);
            var producersDTO = _mapper.Map<IEnumerable<Producer>, IEnumerable<ProducerDTO>>(producers);
            return Ok(producersDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteProducer))]
    public async Task<IActionResult> DeleteProducer(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateProducer))]
    public async Task<IActionResult> CreateProducer([FromBody] ProducerDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ProducerDTO, Producer>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Producer, ProducerDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateProducer))]
    public async Task<IActionResult> UpdateProducer([FromBody] ProducerDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<ProducerDTO, Producer>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Producer, ProducerDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}