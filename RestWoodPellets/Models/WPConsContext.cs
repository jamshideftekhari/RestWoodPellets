using Microsoft.EntityFrameworkCore;

namespace RestWoodPellets.Models
{
    public class WPConsContext : DbContext
    {
        public WPConsContext(DbContextOptions<WPConsContext> options) : base(options) { }   

        public DbSet<WPConstrains> wPConsContexts { get; set; }
    }
}
