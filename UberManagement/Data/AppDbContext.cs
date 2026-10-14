using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UberManagement.Models;

namespace UberManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(s => s.Vehicle)
                .WithOne(d => d.Driver)
                .HasForeignKey<Vehicle>(s => s.DriverId);


            modelBuilder.Entity<Ride>()
                .HasOne(c => c.Driver)
                .WithMany(c => c.RideDrivers)
                .HasForeignKey(d => d.DriverId);



            modelBuilder.Entity<Ride>()
                .HasOne(c => c.Rider)
                .WithMany(x => x.RideRiders)
                .HasForeignKey(d => d.RiderId);


            modelBuilder.Entity<Ride>()
                .HasOne(s => s.Payment)
                .WithOne(d => d.Ride)
                .HasForeignKey<Payment>(s => s.RideId);


            modelBuilder.Entity<Ride>()
                .HasOne(s => s.Rating)
                .WithOne(d => d.Ride)
                .HasForeignKey<Rating>(s => s.RideId);
        }
    }
}
