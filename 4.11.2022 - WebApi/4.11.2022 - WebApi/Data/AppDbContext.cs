using _4._11._2022___WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4._11._2022___WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
