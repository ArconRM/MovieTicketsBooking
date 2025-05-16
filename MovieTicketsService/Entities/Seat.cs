using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class Seat : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid ScreeningRoomId { get; set; }

    public ScreeningRoom ScreeningRoom { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }

    public List<Booking> Bookings { get; set; }
}