using Core.Interfaces;

namespace Common.DTO;

public class MovieDTO: IEntityWithUUID
{
    public Guid UUID { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public Guid ProducerUUID { get; set; }
    
}