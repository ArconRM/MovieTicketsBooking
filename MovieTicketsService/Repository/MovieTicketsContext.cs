using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieTicketsService.Entities;

namespace MovieTicketsService.Repository;

public class MovieTicketsContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }

    public DbSet<MovieShow> MovieShows { get; set; }

    public DbSet<ScreeningRoom> ScreeningRooms { get; set; }

    public DbSet<Seat> Seats { get; set; }

    public DbSet<Theater> Theaters { get; set; }

    public MovieTicketsContext(DbContextOptions<MovieTicketsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}