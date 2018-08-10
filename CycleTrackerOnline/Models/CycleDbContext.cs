using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CycleTrackerOnline.Models
{
    public partial class CycleDbContext : DbContext
    {
        public virtual DbSet<Bikes> Bikes { get; set; }
        public virtual DbSet<Rides> Rides { get; set; }
        public virtual DbSet<RideYears> RideYears { get; set; }

        public CycleDbContext(DbContextOptions<CycleDbContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-POSFKPQ;Database=CycleDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bikes>(entity =>
            {
                entity.HasKey(e => e.BikeId);

                entity.Property(e => e.BikeId)
                    .HasColumnName("BikeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BikeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rides>(entity =>
            {
                entity.HasKey(e => e.RideId);

                entity.Property(e => e.RideId).HasColumnName("RideID");

                entity.Property(e => e.AverageSpeed)
                    .HasColumnType("decimal(10, 2)")
                    .HasComputedColumnSql("(CONVERT([decimal](10,2),[DistanceInMiles]/([TimeInMinutes]/(60))))");

                entity.Property(e => e.BikeId).HasColumnName("BikeID");

                entity.Property(e => e.Calories).HasColumnType("nchar(10)");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.DistanceInKm)
                    .HasColumnType("decimal(10, 2)")
                    .HasComputedColumnSql("(CONVERT([decimal](10,2),[DistanceInMiles]*(1.60934)))");

                entity.Property(e => e.RideDate).HasColumnType("date");

                entity.Property(e => e.TimeInHours)
                    .HasColumnType("decimal(10, 2)")
                    .HasComputedColumnSql("(CONVERT([decimal](10,2),[TimeInMinutes]/(60.00)))");

                entity.HasOne(d => d.Bike)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.BikeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Rides_Bikes1");
            });

            modelBuilder.Entity<RideYears>(entity =>
            {
                entity.HasKey(e => e.YearId);

                entity.Property(e => e.YearId)
                    .HasColumnName("YearID")
                    .ValueGeneratedNever();
            });
        }
    }
}
