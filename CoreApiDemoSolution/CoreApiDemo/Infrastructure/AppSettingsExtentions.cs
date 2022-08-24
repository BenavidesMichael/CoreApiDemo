using CoreApiDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApiDemo.Infrastructure
{
    public static class AppSettingsExtentions
    {
        public static IServiceCollection GetAppSettingsValues(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SettingsConfig>(opt => configuration.GetSection("SettingsConfig").Bind(opt));
            return services;
        }
    }
}
