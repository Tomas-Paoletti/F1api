using Microsoft.EntityFrameworkCore;

namespace f1api.Models
{
    public class F1Context : DbContext
    {
        public F1Context(DbContextOptions<F1Context> options) : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverStats> DriverStats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.DriverStats)
                .WithOne(s => s.Driver)
                .HasForeignKey<Driver>(d => d.IdDriverStats);
        }


    }
}
