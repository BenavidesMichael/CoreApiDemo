using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreApiDemo.Contracts
{
    public interface ITokenStoreRepository
    {
        Tokens GenerateToken(IdentityUser user, IList<string> roles);
        Tokens RefreshToken(IdentityUser user, IList<string> roles);
    }
}
