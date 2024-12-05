using Microsoft.Extensions.DependencyInjection;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Mappers;
using ProfessionDriverApp.Application.Services;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Profiles;

namespace ProfessionDriverApp.Application.Configurations
{
    public class Dependencies
    {
        private static void EntitiesServiciesRegister(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IWorkLogService, WorkLogService>();
            services.AddScoped<IVehicleService, VehicleService>();
        }
        private static void MapperProfilesRegister(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IndividualProfile), typeof(AppUserProfile), typeof(CompanyServiceProfile), typeof(VehicleProfile), typeof(WorkLogProfile), typeof(TransportUnitProfile), typeof(EmployeeProfile));
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
