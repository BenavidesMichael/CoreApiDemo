﻿namespace CoreApiDemo.Entities
{
    public class Actor : Person
    {
        public int Id { get; set; }
        public string Biography { get; set; }

        public IEnumerable<ActorMovie> ActorMovies { get; set; }
    }
}
