using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.Business.Services;

namespace ProfessionDriverApp.Business
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            //add scope dependency for EntityManager to handle HTTP request and create single instance of EntityManager to handle request with same object
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDriverWorkLogEntryService, DriverWorkLogEntryService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IDriverWorkLogService, DriverWorkLogService>();
            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<IVehicleInspectionService, VehicleInspectionService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ILGVService, LGVService>();

            //DI for DataAccess 
            DataAccess.Dependencies.Register(services);
        }
    }
}
