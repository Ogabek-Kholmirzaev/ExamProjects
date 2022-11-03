using _11._02._2022___WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _11._02._2022___WebApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .HasMaxLength(20);
    }
}