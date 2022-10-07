namespace CoreApiDemo.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }

        public HashSet<Genre> Genres { get; set; }
        public HashSet<RoomTheatre> RoomTheatres { get; set; }
        public HashSet<ActorMovie> ActorMovies { get; set; }
    }
}
