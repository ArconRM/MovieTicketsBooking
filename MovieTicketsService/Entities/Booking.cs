using Common.Enums;
using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class Booking : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid MovieShowId { get; set; }
    public MovieShow MovieShow { get; set; }

    public Guid SeatId { get; set; }

    public Seat Seat { get; set; }

    public Guid UserUUID { get; set; }

    public BookingStatus Status { get; set; }
}