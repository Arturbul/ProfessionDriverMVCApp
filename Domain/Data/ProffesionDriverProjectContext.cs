﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ProfessionDriverProjectContext : DbContext
    {
        public ProfessionDriverProjectContext(DbContextOptions<ProfessionDriverProjectContext> options)
        : base(options) { }
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverWorkLog> DriverWorkLogs { get; set; } = null!;
        public DbSet<DriverWorkLogEntry> DriverWorkLogEntries { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Entity> Entities { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public DbSet<LargeGoodsVehicle> LargeGoodsVehicles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; } = null!;
        public DbSet<DriverWorkLogDetail> DriverWorkLogDetails { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AutoIncludes

            //Employee
            modelBuilder.Entity<Employee>().Navigation(en => en.Entity).AutoInclude();

            //Driver
            modelBuilder.Entity<Driver>().Navigation(d => d.Employee).AutoInclude();

            //DriverWorkLogEntry
            modelBuilder.Entity<DriverWorkLogEntry>().Navigation(d => d.Driver).AutoInclude();

            // Vehicle
            modelBuilder.Entity<Vehicle>().Navigation(v => v.Entity).AutoInclude();
            modelBuilder.Entity<Vehicle>().Navigation(v => v.VehicleInsurance).AutoInclude();
            modelBuilder.Entity<Vehicle>().Navigation(v => v.VehicleInspection).AutoInclude();

            // LargeGoodsVehicle
            modelBuilder.Entity<LargeGoodsVehicle>().Navigation(lgv => lgv.Vehicle).AutoInclude();
            modelBuilder.Entity<LargeGoodsVehicle>().Navigation(lgv => lgv.Trailer).AutoInclude();
            modelBuilder.Entity<LargeGoodsVehicle>().Navigation(lgv => lgv.DriverWorkLogs).AutoInclude();

            // VehicleInsurance
            modelBuilder.Entity<VehicleInsurance>().Navigation(vi => vi.OC_Policy).AutoInclude();
            modelBuilder.Entity<VehicleInsurance>().Navigation(vi => vi.AC_Policy).AutoInclude();

            //Relations

            modelBuilder.Entity<Driver>()
                .HasMany(d => d.DriverWorkLogs)
                .WithOne(wl => wl.Driver)
                .HasForeignKey(wl => wl.DriverId);

            modelBuilder.Entity<DriverWorkLog>()
                .HasOne(wl => wl.DriverWorkLogDetail)
                .WithOne(wld => wld.DriverWorkLog)
                .HasForeignKey<DriverWorkLogDetail>(wl => wl.DriverWorkLogId);

            modelBuilder.Entity<DriverWorkLogDetail>()
                .HasMany(wld => wld.DriverWorkLogEntries)
                .WithOne(wle => wle.DriverWorkLogDetail)
                .HasForeignKey(wle => wle.DriverWorkLogDetailId);

        }
        #endregion

    }
}
