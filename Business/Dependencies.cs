using Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public class Dependencies
    {
        public static void Register(IServiceCollection services)
        {
            //add scope dependency for EntityManager to handle HTTP request and create single instance of EntityManager to handle request with same object
            services.AddScoped<IEntityManager, EntityManager>();


            //DI for DataAccess 
            DataAccess.Dependencies.Register(services);
        }
    }
}
