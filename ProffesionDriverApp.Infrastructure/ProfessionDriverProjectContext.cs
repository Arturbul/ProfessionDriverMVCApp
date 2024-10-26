using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Infrastructure
{
    public class ProfessionDriverProjectContext : IdentityDbContext
    {
        public ProfessionDriverProjectContext(DbContextOptions<ProfessionDriverProjectContext> options)
        : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverWorkLog> DriverWorkLogs { get; set; } = null!;
        public DbSet<DriverWorkLogEntry> DriverWorkLogEntries { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Individual> Individuals { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public DbSet<LargeGoodsVehicle> LargeGoodsVehicles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; } = null!;

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relations
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.DriverWorkLogs)
                .WithOne(wl => wl.Driver)
                .HasForeignKey(wl => wl.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Individual>()
                .OwnsOne(a => a.Address);

            modelBuilder.Entity<Employee>()
                .OwnsOne(a => a.Address);
        }
        #endregion

    }
}
