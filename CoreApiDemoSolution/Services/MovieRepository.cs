using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                   RoomTheatres = m.RoomTheatres.Select(rt => rt.Price),
                   TheaterName = m.RoomTheatres.Select(t => t.Theater.Name).FirstOrDefault(),
                   Actors = m.ActorMovies.OrderBy(x => x.Actor.Name)
                                   .Select(a => new { a.Actor.Name, a.Actor.Birthdate }),
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
                Actors = movie.Actors.Select(a => new Models.Actor { Name = a.Name, Birthdate = a.Birthdate }),
            };
        }


        public async Task<Object> GetMoviesRelease()
        {
            var resukt = await _context.Movies.GroupBy(x => x.IsAvailable)
                .Select(g => new
                {
                    IsAvailable = g.Key,
                    NoMoviesRelease = g,
                });
            //return 
            //    .Select(g => new MoviesRelease
            //    {
            //        IsAvailable = g.Key,
            //        NoMoviesRelease = g.Count(),
            //        Movies = null,
            //        //Movies = x.Select(m => new
            //        //{
            //        //    m.Title,
            //        //    m.UrlImage,
            //        //    m.ReleaseDate
            //        //}).AsEnumerable(),
            //    });
        }
    }
}
