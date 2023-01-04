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
            return await _context.Movies
                .Where(x => x.Id == id)
                .Include(g => g.Genres.OrderByDescending(x => x.Id))
                .Include(rt => rt.RoomTheatres)
                    .ThenInclude(t => t.Theater)
                .Include(act => act.ActorMovies)
                    .ThenInclude(am => am.Actor)
                .Select(m => new Models.Movie
                {
                    Id = m.Id,
                    Title = m.Title,
                    UrlImage = m.UrlImage,
                    IsAvailable = m.IsAvailable,
                    ReleaseDate = m.ReleaseDate,
                    Genres = m.Genres.Select(g => g.Name),
                    RoomTheatres = m.RoomTheatres.Select(rt => rt.Price),
                    TheaterName = m.RoomTheatres.Select(t => t.Theater.Name).FirstOrDefault(),
                    Actors = m.ActorMovies.Select(a => new Models.Actor { Name = a.Actor.Name, Birthdate = a.Actor.Birthdate }),
                }).FirstOrDefaultAsync();
        }
    }
}
