using CoreApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Infrastructure
{
    public static class DataBaseExtentions
    {
        public static string GetDefaultConnectionString(this IConfiguration Configuration, string name)
        {
            return Configuration.GetConnectionString(name);
        }


        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<NetCoreApiDemoContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetDefaultConnectionString("DemoApi"),
                    sqlserver =>
                    {
                        sqlserver.UseNetTopologySuite();
                        sqlserver.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // AsNoTracking Global ⇒ query read only
            });
            return services;
        }
    }
}
