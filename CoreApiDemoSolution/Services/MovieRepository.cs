using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly NetCoreApiDemoContext _context;

        public MovieRepository(NetCoreApiDemoContext context)
        {
            this._context = context;
        }


        public async Task<Models.Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.AsNoTracking()
               .Where(x => x.Id == id)
               .Select(m => new
               {
                   m.Id,
                   m.Title,
                   m.UrlImage,
                   m.IsAvailable,
                   m.ReleaseDate,
                   Genres = m.Genres.Select(g => g.Name),
                   RoomTheatres = m.Rooms.Select(rt => rt.Price),
                   TheaterName = m.Rooms.Select(t => t.Theater.Name).FirstOrDefault(),
                   Actors = m.ActorMovies.OrderBy(x => x.Actor.FullName)
                                   .Select(a => new { a.Actor.FullName, a.Actor.Birthdate }),
               }).SingleOrDefaultAsync();

            return new Models.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                UrlImage = movie.UrlImage,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Genres = movie.Genres,
                RoomTheatres = movie.RoomTheatres,
                TheaterName = movie.TheaterName,
                Actors = movie.Actors.Select(a => new Models.Actor { Name = a.FullName, Birthdate = a.Birthdate }),
            };
        }

    }
}
