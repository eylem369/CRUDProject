using CRUDProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options){}

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<AppUser> Users { get; set; }

    }
}
