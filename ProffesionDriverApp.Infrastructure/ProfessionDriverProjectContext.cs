using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Infrastructure
{
    public class ProfessionDriverProjectContext : DbContext
    {
        public ProfessionDriverProjectContext(DbContextOptions<ProfessionDriverProjectContext> options)
        : base(options) { }
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverWorkLog> DriverWorkLogs { get; set; } = null!;
        public DbSet<DriverWorkLogEntry> DriverWorkLogEntries { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Individual> Entities { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public DbSet<LargeGoodsVehicle> LargeGoodsVehicles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; } = null!;

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relations
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.DriverWorkLogs)
                .WithOne(wl => wl.Driver)
                .HasForeignKey(wl => wl.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

        }
        #endregion

    }
}
