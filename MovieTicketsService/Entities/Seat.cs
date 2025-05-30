using Core.Interfaces;

namespace MovieTicketsService.Entities;

public class Seat : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid ScreeningRoomUUID { get; set; }

    public ScreeningRoom ScreeningRoom { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }
}