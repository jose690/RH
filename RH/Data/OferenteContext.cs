using Microsoft.EntityFrameworkCore;

namespace RH.Data
{
    public class OferenteContext(DbContextOptions<OferenteContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Oferente { get; set; }
    }
}
