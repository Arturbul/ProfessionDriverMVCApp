using DataAccess.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
