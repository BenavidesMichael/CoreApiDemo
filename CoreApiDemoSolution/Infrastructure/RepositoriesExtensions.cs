using CoreApiDemo.Contracts;
using CoreApiDemo.Services;

namespace CoreApiDemo.Infrastructure
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            return services;
        }
    }
}
