using Microsoft.EntityFrameworkCore;

namespace RestWoodPellets.Models
{
    public class WoodPalletContext : DbContext
    {
        public WoodPalletContext(DbContextOptions<WoodPalletContext> options) : base(options) { }

        public DbSet<WoodPallet> WoodPallets { get; set; }

    }
}
