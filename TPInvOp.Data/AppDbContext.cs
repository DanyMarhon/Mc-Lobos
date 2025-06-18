using Microsoft.EntityFrameworkCore;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext() { }
        public DbSet<Category> Categories { get; set; }


        //{(Creo yo que deberiamos usar la conexión del DI acá y no esta
        //Pero con esta funciona
        //att Kevin})
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog = McLobosLite; Trusted_Connection = true; TrustServerCertificate = true");
        }
    }
}
