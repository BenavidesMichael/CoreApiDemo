using CoreApiDemo.Contracts;
using CoreApiDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApiDemo.Infrastructure
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
