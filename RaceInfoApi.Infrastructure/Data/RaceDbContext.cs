using Microsoft.EntityFrameworkCore;
using RaceInfoApi.Core.Entities;
using RaceInfoApi.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Data
{
    public class RaceDbContext : DbContext
    {
        public RaceDbContext(DbContextOptions<RaceDbContext> options) : base(options) { }

        public DbSet<Race> Races => Set<Race>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<RaceResult> RaceResults { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RaceConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new RaceResultConfiguration());
            modelBuilder.Entity<RaceResult>(entity =>
            {
                entity.ToTable("raceresults");

                entity.HasKey(e => e.id);

                entity.Property(e => e.Position).IsRequired();

                entity.Property(e => e.FinishTime).HasMaxLength(50);
                entity.Property(e => e.BestLapTime).HasMaxLength(50);

                entity.HasOne(e => e.Race)
                    .WithMany(r => r.Results)
                    .HasForeignKey(e => e.RaceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Driver)
                    .WithMany(d => d.Results)
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
