using CoreApiDemo.Models;

namespace CoreApiDemo.Infrastructure
{
    public static class AppSettingsExtentions
    {
        public static IServiceCollection GetAppSettingsValues(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.JWTSetting));
            return services;
        }
    }
}
