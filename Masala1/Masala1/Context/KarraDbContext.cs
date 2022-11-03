using Masala1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Masala1.Context
{
    public class KarraDbContext : DbContext
    {
        public DbSet<Karra> Karra { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=data.db");
        }
    }
}
