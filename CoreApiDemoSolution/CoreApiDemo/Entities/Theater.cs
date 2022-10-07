using NetTopologySuite.Geometries;

namespace CoreApiDemo.Entities
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        public TheaterOffer TheaterOffer { get; set; }
        // HashSet n'ordone pas, use Icolection
        public HashSet<RoomTheatre> RoomTheatres { get; set; }
    }
}
