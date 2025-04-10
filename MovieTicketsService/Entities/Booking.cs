using Common.Enums;
using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class Booking : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid MovieShowUUID { get; set; }

    public Guid SeatUUID { get; set; }

    public Guid UserUUID { get; set; }

    public BookingStatus Status { get; set; }
}