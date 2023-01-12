namespace CoreApiDemo.Models;

public class MoviesRelease
{
    public bool IsAvailable { get; set; }
    public int NoMoviesRelease { get; set; }
    public IEnumerable<Models.Movie> Movies { get; set; }
}
