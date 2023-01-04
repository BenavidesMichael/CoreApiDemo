namespace CoreApiDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<decimal> RoomTheatres { get; set; }
        public string TheaterName { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
