using Core.Interfaces;

namespace Common.DTO.MovieTickets;

public class SeatFullDTO : IEntityWithUUID
{
    public Guid UUID { get; set; }

    public ScreeningRoomWithIdsDTO ScreeningRoom { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }
}