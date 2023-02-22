namespace CoreApiDemo.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Biography { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }

        public IEnumerable<ActorMovie> ActorMovies { get; set; }
    }
}
