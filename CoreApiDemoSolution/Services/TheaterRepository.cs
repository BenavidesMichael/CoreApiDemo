using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace CoreApiDemo.Services
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly NetCoreApiDemoContext _context;

        public TheaterRepository(NetCoreApiDemoContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Models.Theatre>> GetAllTheatres()
        {
            return await _context.Theatres
                                 .Select(t => new Models.Theatre
                                 {
                                     Name = t.Name,
                                     Latitude = t.Location.Y,
                                     Longitude = t.Location.X,
                                 }).ToListAsync();
        }


        public async Task<IEnumerable<Models.Theatre>> GetNearTheatres(double longitude, double latitude, int kilommetres = 5)
        {
            var goemetryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326); // sri cherche sur toute la terre

            var myLocation = goemetryFactory.CreatePoint(new Coordinate(longitude, latitude));
            double kilommetresToMetres  = kilommetres * 1000;

            var theatres = await _context.Theatres
                                 .Where(l => l.Location.IsWithinDistance(myLocation, kilommetresToMetres))
                                 .OrderBy(l => l.Location.Distance(myLocation))
                                 .Select(t => new Models.Theatre
                                 {
                                     Name = t.Name,
                                     Latitude = t.Location.Y,
                                     Longitude = t.Location.X,
                                     Distance = $"{Math.Round(t.Location.Distance(myLocation)) / 1000}km",
                                 }).ToListAsync();

            return theatres;
        }
      
    }
}
