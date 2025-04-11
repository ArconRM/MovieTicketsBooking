using System.Collections.Concurrent;
using MovieDataService.Entities;
using MovieDataService.Service.Interfaces;
using Newtonsoft.Json;

namespace MovieDataService.Service;

public class FromFileEntitySaverService : IFromFileEntitySaverService
{
    private readonly IMovieService _movieService;

    public FromFileEntitySaverService(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<ICollection<Movie>> SaveFromStreamAsync(Stream stream, CancellationToken token)
    {
        using StreamReader streamReader = new(stream);
        string json = streamReader.ReadToEnd();
        List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(json);

        int count = 0;
        ConcurrentBag<Movie> savedMoviesBag = new();
        // Нельзя общий контекст для нескольких потоков бля
        // await Parallel.ForEachAsync(
        //     movies,
        //     new ParallelOptions() { MaxDegreeOfParallelism = 4 },
        //     async (movie, parallelToken) =>
        //     {
        //         Movie saved = await _movieService.CreateAsync(movie, token);
        //         Interlocked.Increment(ref count);
        //         savedMoviesBag.Add(saved);
        //     });

        foreach (Movie movie in movies)
        {
            Movie saved = await _movieService.CreateAsync(movie, token);
            Interlocked.Increment(ref count);
            savedMoviesBag.Add(saved);
        }

        return savedMoviesBag.ToList();
    }
}