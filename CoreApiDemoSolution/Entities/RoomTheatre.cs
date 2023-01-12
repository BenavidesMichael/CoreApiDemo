namespace CoreApiDemo.Entities
{
    public class RoomTheatre
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public TypeRoomTheatre TypeRoomTheatre { get; set; }

        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
