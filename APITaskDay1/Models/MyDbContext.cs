using Microsoft.EntityFrameworkCore;

namespace APITaskDay1.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
