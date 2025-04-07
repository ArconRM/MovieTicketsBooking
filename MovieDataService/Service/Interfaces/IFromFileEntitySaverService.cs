using MovieDataService.Entities;

namespace MovieDataService.Service.Interfaces;

public interface IFromFileEntitySaverService
{
    Task<ICollection<Movie>> SaveFromStreamAsync(Stream stream, CancellationToken token);
}