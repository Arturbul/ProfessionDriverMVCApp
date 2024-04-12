using Business.Interface;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            //add scope dependency for EntityManager to handle HTTP request and create single instance of EntityManager to handle request with same object
            services.AddScoped<IEntityManager, EntityManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IDriverWorkLogEntryManager, DriverWorkLogEntryManager>();
            services.AddScoped<IDriverManager, DriverManager>();
            services.AddScoped<IDriverWorkLogManager, DriverWorkLogManager>();
            services.AddScoped<IInsurancePolicyManager, InsurancePolicyManager>();
            services.AddScoped<IVehicleInspectionManager, VehicleInspectionManager>();
            services.AddScoped<IVehicleManager, VehicleManager>();
            services.AddScoped<ILGVManager, LGVManager>();

            //DI for DataAccess 
            DataAccess.Dependencies.Register(services);
        }
    }
}
