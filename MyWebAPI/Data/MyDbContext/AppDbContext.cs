using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data.MyDbContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<Entity.Person> Persons { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
    }
}
