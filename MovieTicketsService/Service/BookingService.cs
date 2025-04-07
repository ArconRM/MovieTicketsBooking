using Core.BaseEntities;
using Core.Interfaces;
using MovieTicketsService.Entities;
using MovieTicketsService.Service.Interfaces;

namespace MovieTicketsService.Service;

public class BookingService : BaseService<Booking>, IBookingService
{
    private readonly IRepository<Booking> _repository;

    public BookingService(IRepository<Booking> repository) : base(repository)
    {
        _repository = repository;
    }
}