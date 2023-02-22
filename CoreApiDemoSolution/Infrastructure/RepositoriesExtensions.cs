using CoreApiDemo.Contracts;
using CoreApiDemo.Services;

namespace CoreApiDemo.Infrastructure
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITokenStoreRepository, TokenStoreRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
