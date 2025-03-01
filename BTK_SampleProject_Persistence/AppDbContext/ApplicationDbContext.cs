
using BTK_SampleProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace BTK_SampleProject.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }//encapsulation
        public DbSet<Category> Categories { get; set; }


    }
}
