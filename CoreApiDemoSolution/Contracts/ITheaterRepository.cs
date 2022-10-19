namespace CoreApiDemo.Contracts
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Models.Theatre>> GetAllTheatres();
        Task<IEnumerable<Models.Theatre>> GetNearTheatres(double longitude, double latitude, int kilommetres);
    }
}
