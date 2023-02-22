using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using Microsoft.AspNetCore.Identity;

namespace CoreApiDemo.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<Person> _userManager;

        public UserRepository(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
