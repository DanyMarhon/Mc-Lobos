using Microsoft.EntityFrameworkCore;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
