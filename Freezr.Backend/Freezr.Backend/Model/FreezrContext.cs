using Microsoft.EntityFrameworkCore;

namespace Freezr.Backend.Model
{
    public class FreezrContext : DbContext
    {
        public FreezrContext(DbContextOptions<FreezrContext> options) : base(options)
        {
        }

        public DbSet<Fridge> Fridges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var fridge = new Fridge { FridgeId = 1, Name = "Kitchen" };
            modelBuilder.Entity<Fridge>().HasData(fridge);
        }
    }
}
