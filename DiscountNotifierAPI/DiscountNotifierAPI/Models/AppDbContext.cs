using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DiscountNotifierAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var seedData = SeedData.SeedData.GetData();

            foreach(var manufacturer in seedData.Manufacturers)
            {
                modelBuilder.Entity<Manufacturer>().HasData(manufacturer);
            }
            foreach(var beacon in seedData.Beacons)
            {
                modelBuilder.Entity<Beacon>().HasData(beacon);
            }
            foreach(var region in seedData.Regions)
            {
                modelBuilder.Entity<Region>().HasData(region);
            }
            foreach(var discount in seedData.Discounts)
            {
                modelBuilder.Entity<Discount>().HasData(discount);
            }
        }
    }
}
