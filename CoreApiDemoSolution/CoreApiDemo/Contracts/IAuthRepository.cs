using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreApiDemo.Contracts
{
    public interface IAuthRepository
    {
        Task<AuthResponse> LoginAsync(Login model);
        Task<bool> IsLoginAccesCorrectAsync(Login model);
        Task<IdentityResult> RegisterAsync(Register model);
        Task LogoutAsync();
    }
}
