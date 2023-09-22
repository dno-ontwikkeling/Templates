using Microsoft.EntityFrameworkCore;

namespace MyTemplate.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}