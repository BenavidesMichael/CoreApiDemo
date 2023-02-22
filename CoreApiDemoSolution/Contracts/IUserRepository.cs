using CoreApiDemo.Entities;

namespace CoreApiDemo.Contracts
{
    public interface IUserRepository
    {
        Task<Person> GetPersonByEmail(string email);
    }
}
