using Masala3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Masala3.AppDbContext
{
    public class ExamDbContext:DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        public ExamDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
