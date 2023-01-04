namespace CoreApiDemo.Contracts;

public interface IMovieRepository
{
    Task<Models.Movie> GetMovieById(int id);
}
