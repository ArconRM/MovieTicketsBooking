using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class SeatWithIdsDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid ScreeningRoomUUID { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }
}