using Microsoft.EntityFrameworkCore;

namespace CoffeeShopDataLayer
{
    public class CoffeeShopDbContext : DbContext
    {
        public DbSet<CoffeeShop> CoffeeShops => Set<CoffeeShop>();

        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CoffeeShop>().HasKey(c => c.Id);
        }
    }
}