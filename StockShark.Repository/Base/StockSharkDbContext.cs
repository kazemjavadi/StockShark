using Microsoft.EntityFrameworkCore;
using StockShark.Core.Entities;

namespace StockShark.Repository.Base
{
    public class StockSharkDbContext : DbContext
    {
        public StockSharkDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<History> Histories { get; set; }
        public DbSet<Share> Shares { get; set; }
    }
}
