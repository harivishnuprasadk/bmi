using System;
using Microsoft.EntityFrameworkCore;
using BmiApp.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Data.SqlClient;
namespace BmiApp.Models
{
	public class BmiDbContext:DbContext
	{
        public BmiDbContext(DbContextOptions<BmiDbContext> options)
            : base(options)
        {
        }

        public DbSet<BmiMetrics> BmiMetrics { get; set; }
        public DbSet<BmiUserData>? BmiUserData { get; set; }
        public DbSet<BmiUserHealthData> BmiUserHealthData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BmiUserHealthData>()
                    .HasOne(e => e.BmiUserData)
                    .WithMany(e => e.BmiUserHealthData)
                    .HasForeignKey(e => e.FkBmiUserData)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BmiMetrics>().Property(bmiMetric => bmiMetric.WeightStatus).HasConversion(
                v=>v.ToString(),
                v => (WeightStatus)Enum.Parse(typeof(WeightStatus), v));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}


//protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //modelBuilder.Entity<Rider>().Property(e => e.Mount).HasConversion(v => v.ToString(), v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
//}

