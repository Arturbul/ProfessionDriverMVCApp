using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.DataAccess.Repositories;

namespace ProfessionDriverApp.DataAccess
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDriverWorkLogEntryRepository, DriverWorkLogEntryRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverWorkLogRepository, DriverWorkLogRepository>();
            services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();
            services.AddScoped<IVehicleInspectionRepository, VehicleInspectionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ILGVRepository, LGVRepository>();
        }
    }
}
