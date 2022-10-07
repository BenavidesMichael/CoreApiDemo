using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly NetCoreApiDemoContext _context;

        public GenreRepository(NetCoreApiDemoContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Models.Genre>> GetAllGenres()
        {
            return await this._context.Genres.Select(g => new Models.Genre
            {
                Name = g.Name,
            }).ToListAsync();
        }
    }
}
