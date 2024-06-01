using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PobreLibrary.Core.Entities;

namespace PobreLibrary.Infrastructure.Persistence;

public class PobreLibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; private set; }

    public PobreLibraryDbContext(DbContextOptions<PobreLibraryDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}