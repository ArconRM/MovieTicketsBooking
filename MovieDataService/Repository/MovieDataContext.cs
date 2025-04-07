using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;

namespace MovieDataService.Repository;

public class MovieDataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Person> Persons { get; set; }

    public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}