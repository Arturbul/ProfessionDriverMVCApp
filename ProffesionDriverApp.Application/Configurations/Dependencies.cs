using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Services;
using ProfessionDriverApp.Domain.Profiles;

namespace ProfessionDriverApp.Application.Configurations
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            //add scope dependency for EntityManager to handle HTTP request and create single instance of EntityManager to handle request with same object
            services.AddScoped<IIndividualService, IndividualService>();
            services.AddAutoMapper(typeof(IndividualProfile));

            //DI for DataAccess 
            Infrastructure.Configurations.Dependencies.Register(services);
        }
    }
}
