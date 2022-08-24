using Microsoft.Extensions.DependencyInjection;

namespace CoreApiDemo.Infrastructure
{
    public static class CorsExtentions
    {
        public static IServiceCollection AddCorsExtention(this IServiceCollection services)
        {
            services.AddCors(opt => opt.AddDefaultPolicy(builder => 
            {
                builder.WithOrigins("https://*")
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return services;
        }
    }
}
