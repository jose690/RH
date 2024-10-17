using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class TSEContext : DbContext
    {
        public TSEContext()
        {
        }
        public TSEContext(DbContextOptions<TSEContext> options) : base(options)
        {
        }

        // Define la tabla TSE con el modelo de datos Usuario
        public DbSet<Usuario> TSE { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mark Usuario as keyless
            modelBuilder.Entity<Usuario>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
