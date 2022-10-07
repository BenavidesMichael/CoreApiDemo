using CoreApiDemo.Entities.Configuration.Conventions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CoreApiDemo.Entities
{
    public class NetCoreApiDemoContext : IdentityDbContext
    {
        public NetCoreApiDemoContext(DbContextOptions<NetCoreApiDemoContext> options)
            : base(options)
        { }


        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theatres { get; set; }
        public DbSet<TheaterOffer> TheaterOffers { get; set; }
        public DbSet<RoomTheatre> RoomTheatres { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            DateTimeConvention.Convert(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            DataSeed.Seed(builder);
        }
    }
}
