using AutoMapper;
using Common.DTO;
using Common.DTO.MovieTickets;
using Microsoft.AspNetCore.Mvc;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Controllers;

public class BookingController : Controller
{
    private readonly ILogger<BookingController> _logger;

    private readonly IMapper _mapper;

    private readonly IBookingService _service;

    public BookingController(ILogger<BookingController> logger, IMapper mapper, IBookingService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet(nameof(GetBooking))]
    public async Task<IActionResult> GetBooking(Guid id, CancellationToken token)
    {
        try
        {
            var booking = await _service.GetAsync(id, token);
            var bookingDTO = _mapper.Map<Booking, BookingDTO>(booking);
            return Ok(bookingDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    [HttpGet(nameof(GetAllBookings))]
    public async Task<IActionResult> GetAllBookings(CancellationToken token)
    {
        try
        {
            var bookings = await _service.GetAllAsync(token);
            var bookingsDTO = _mapper.Map<IEnumerable<Booking>, IEnumerable<BookingDTO>>(bookings);
            return Ok(bookingsDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete(nameof(DeleteBooking))]
    public async Task<IActionResult> DeleteBooking(Guid id, CancellationToken token)
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

    [HttpPost(nameof(CreateBooking))]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<BookingDTO, Booking>(entityDTO);
            var newEntity = await _service.CreateAsync(entity, token);
            var newEntityDTO = _mapper.Map<Booking, BookingDTO>(newEntity);
            return Ok(newEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPatch(nameof(UpdateBooking))]
    public async Task<IActionResult> UpdateBooking([FromBody] BookingDTO entityDTO, CancellationToken token)
    {
        try
        {
            var entity = _mapper.Map<BookingDTO, Booking>(entityDTO);
            var updatedEntity = await _service.UpdateAsync(entity, token);
            var updatedEntityDTO = _mapper.Map<Booking, BookingDTO>(updatedEntity);
            return Ok(updatedEntityDTO);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}