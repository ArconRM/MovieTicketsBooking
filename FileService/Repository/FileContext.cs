using System.Reflection;
using FileService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileService.Repository;

public class FileContext : DbContext
{
    public DbSet<FileRecord> Files { get; set; }

    public FileContext(DbContextOptions<FileContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}