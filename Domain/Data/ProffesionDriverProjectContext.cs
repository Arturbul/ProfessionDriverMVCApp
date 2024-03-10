using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ProffesionDriverProjectContext : DbContext
    {
        public ProffesionDriverProjectContext(DbContextOptions<ProffesionDriverProjectContext> options)
        : base(options) { }
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverWorkLog> DriverWorkLogs { get; set; } = null!;
        public DbSet<DriverWorkLogEntry> DriverWorkLogEntrys { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Entity> Entitys { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicys { get; set; } = null!;
        public DbSet<LargeGoodsVehicle> LargeGoodsVehicles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; } = null!;

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        #endregion
    }
}
