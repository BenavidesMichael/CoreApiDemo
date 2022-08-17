using CoreApiDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApiDemo.Infrastructure
{
    public static class ConfigurationExtentions
    {
        public static string GetDefaultConnectionString(this IConfiguration Configuration, string name)
        {
            return Configuration.GetConnectionString(name);
        }


        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<NetCoreApiDemoContext>(options
                    => options.UseSqlServer(Configuration.GetDefaultConnectionString("NetCoreApiDemoConnectionString")));
            return services;
        }
    }
}
