using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Infrastructure
{
    public class ProfessionDriverProjectContext : IdentityDbContext
    {
        public ProfessionDriverProjectContext(DbContextOptions<ProfessionDriverProjectContext> options)
        : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverWorkLog> DriverWorkLogs { get; set; } = null!;
        public DbSet<DriverWorkLogEntry> DriverWorkLogEntries { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; } = null!;
        public DbSet<LargeGoodsVehicle> LargeGoodsVehicles { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public DbSet<VehicleInsurance> VehicleInsurances { get; set; } = null!;
        public DbSet<TransportUnit> TransportUnits { get; set; } = null!;

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
               .HasIndex(u => u.Email)
               .IsUnique();

            //Relations
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.DriverWorkLogs)
                .WithOne(wl => wl.Driver)
                .HasForeignKey(wl => wl.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                .OwnsOne(a => a.Address);

            modelBuilder.Entity<Company>()
                .OwnsOne(a => a.Address);

            modelBuilder.Entity<Company>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne(a => a.AppUser)
                .WithOne(a => a.Employee)
                .HasForeignKey<AppUser>(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Driver>()
                .HasOne(a => a.Employee)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverWorkLog>()
                .HasOne(a => a.TransportUnit)
                .WithMany(a => a.DriverWorkLogs)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Driver>()
                .HasOne(a => a.Employee)
                .WithOne(a => a.Driver)
                .HasForeignKey<Driver>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        #endregion
    }
}
