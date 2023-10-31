using Microsoft.EntityFrameworkCore;

namespace RestWoodPellets.Models
{
    public class WPContextSql : DbContext
    {
        public WPContextSql(DbContextOptions<WPContextSql> options) : base(options) { }

        public DbSet<WoodPallet> Wood { get; set; }
    }
}
