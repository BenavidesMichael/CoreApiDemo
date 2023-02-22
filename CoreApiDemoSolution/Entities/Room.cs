namespace CoreApiDemo.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }

        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
