using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MoviesService.Entities;
using MoviesService.Repository.EntityConfiguration;

namespace MoviesService.Repository;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}