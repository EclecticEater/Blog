using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        { 
        }
        public DbSet<People> People { get; set; }

        public DbSet<Post> Posts { get; set; }


    }
}
