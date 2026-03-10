using Calligraphy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Calligraphy.Infrastructure;

public class CallyDbContext : DbContext
{
    public DbSet<GameResultRecord> GameResultRecords { get; set; }
    
    public CallyDbContext(DbContextOptions<CallyDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Cally.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<GameResultRecord>()
            .HasKey(e => e.GameId);
    }
    
    public bool CreateDatabase(bool delete) {
        if (delete) {
            Database.EnsureDeleted();
        }

        return Database.EnsureCreated();
    }
}