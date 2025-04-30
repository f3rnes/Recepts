using Microsoft.EntityFrameworkCore;
using ReceptsAPI.Entity;

namespace ReceptsAPI
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recept> Recepts { get; set; }
        public DbSet<Stage> Stages{ get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
