namespace CoreApiDemo.Entities
{
    public class RoomTheatre
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TypeRoomTheatre TypeRoomTheatre { get; set; }

        public int TheatreId { get; set; }
        public Theater Theater { get; set; }

        public HashSet<Movie> Movies { get; set; }
    }
}
