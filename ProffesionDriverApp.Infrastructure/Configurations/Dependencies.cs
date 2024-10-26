using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Infrastructure.Configurations
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
