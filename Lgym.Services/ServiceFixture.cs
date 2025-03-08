using Lgym.Services.Configurations;
using Lgym.Services.Interfaces;
using Lgym.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lgym.Services
{
    public static class ServiceFixture
    {
        public static void InitializeMain(this IServiceCollection context, IConfiguration configuration)
        {
            AddConfigurationSingleton<SecuritySettings>(context, configuration, "SecuritySettings");
            AddConfigurationSingleton<JwtSettings>(context, configuration, "JwtSettings");

            context.AddScoped<IUserService, UserService>();
            context.AddScoped<IGymService, GymService>();


            context.AddSingleton<IRoleService, RoleService>();
            context.AddScoped<ICurrentUserService, CurrentUserService>();
            context.AddScoped<IBaseCurrentUserService, BaseCurrentUserService>();

        }


        private static void AddConfigurationSingleton<T>(IServiceCollection context, IConfiguration configuration, string sectionName) where T : class
        {
            var section = configuration.GetSection(sectionName);
            var instance = section.Get<T>();
            context.AddSingleton(instance);
        }
    }
}
