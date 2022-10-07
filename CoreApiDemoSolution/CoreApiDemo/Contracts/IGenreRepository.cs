namespace CoreApiDemo.Contracts
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Models.Genre>> GetAllGenres();
    }
}
