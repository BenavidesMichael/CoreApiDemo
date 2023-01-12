using NetTopologySuite.Geometries;

namespace CoreApiDemo.Entities
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        public TheaterOffer TheaterOffer { get; set; }
        public IEnumerable<RoomTheatre> RoomTheatres { get; set; }
    }
}
