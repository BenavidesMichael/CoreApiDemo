using NetTopologySuite.Geometries;

namespace CoreApiDemo.Entities
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        public Offer Offer { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
