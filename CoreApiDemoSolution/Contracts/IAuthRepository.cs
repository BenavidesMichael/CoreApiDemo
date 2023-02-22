using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreApiDemo.Contracts
{
    public interface IAuthRepository
    {
        Task<Tokens> LoginAsync(string email);
        Task<bool> IsLoginAccesCorrectAsync(Login model);
        Task<IdentityResult> RegisterAsync(Register model);
        Task<Tokens> RefreshToken();
    }
}