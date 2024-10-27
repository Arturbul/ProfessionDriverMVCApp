using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Services;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Profiles;

namespace ProfessionDriverApp.Application.Configurations
{
    public class Dependencies
    {
        private static void EntitiesServiciesRegister(IServiceCollection services)
        {
            services.AddScoped<IIndividualService, IndividualService>();
        }
        private static void MapperProfilesRegister(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IndividualProfile));
        }
        private static void UserAuthServiciesRegister(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserContextService, UserContextService>();
        }

        public static void Register(IServiceCollection services)
        {
            UserAuthServiciesRegister(services);
            EntitiesServiciesRegister(services);
            MapperProfilesRegister(services);

            //DI for DataAccess 
            Infrastructure.Configurations.Dependencies.Register(services);
        }
    }
}
