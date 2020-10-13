using Freezr.Entities;
using Microsoft.EntityFrameworkCore;

namespace Freezr.Model
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

            modelBuilder.Entity<Fridge>().Property(f => f.FridgeId).ValueGeneratedOnAdd();
        }
    }
}
