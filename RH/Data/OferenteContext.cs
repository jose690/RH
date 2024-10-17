using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class OferenteContext : DbContext
    {
        public OferenteContext()
        {
        }
        public OferenteContext(DbContextOptions<OferenteContext> options) : base(options)
        {
        }

        // Define la tabla Oferente con el modelo de datos Usuario
        public DbSet<Oferente> Oferentes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mark Usuario as keyless
            modelBuilder.Entity<Oferente>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}