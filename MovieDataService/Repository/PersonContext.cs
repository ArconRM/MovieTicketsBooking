using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieDataService.Entities;

namespace MovieDataService.Repository;

public class PersonContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}