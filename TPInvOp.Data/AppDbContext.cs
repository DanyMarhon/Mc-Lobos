using Microsoft.EntityFrameworkCore;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data
{
    public class AppDbContext : DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

    }
}
