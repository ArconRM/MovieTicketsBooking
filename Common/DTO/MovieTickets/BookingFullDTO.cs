using Common.Enums;
using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class BookingFullDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public MovieShowWithIdsDTO MovieShow { get; set; }

    public SeatWithIdsDTO Seat { get; set; }

    public Guid UserUUID { get; set; }

    public BookingStatus Status { get; set; }
}