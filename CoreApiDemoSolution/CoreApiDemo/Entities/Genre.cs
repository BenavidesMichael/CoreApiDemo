namespace CoreApiDemo.Entities
{
    //[Table(nameof(Genre), Schema = "Movie")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<Movie> Movies { get; set; }
    }
}
