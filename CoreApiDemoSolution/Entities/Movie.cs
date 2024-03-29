﻿namespace CoreApiDemo.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlImage { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<ActorMovie> ActorMovies { get; set; }
    }
}
