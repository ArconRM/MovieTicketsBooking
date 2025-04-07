using Core.Interfaces;

namespace Common.DTO;

public class SeatDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public Guid ScreeningRoomUUID { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }
}