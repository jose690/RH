using Microsoft.EntityFrameworkCore;

namespace RH.Data
{
    public class TSEContext(DbContextOptions<TSEContext> options) : DbContext(options)
    {
        public DbSet<Usuario> TSE { get; set; }
    }
}