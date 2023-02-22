using CoreApiDemo.Contracts;
using CoreApiDemo.Entities;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreApiDemo.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Person> _userManager;
        private readonly ITokenStoreRepository _tokenStoreRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(
            UserManager<Person> userManager,
            IHttpContextAccessor httpContextAccessor,
            ITokenStoreRepository tokenStoreRepository)
        {
            _userManager = userManager;
            _tokenStoreRepository = tokenStoreRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsLoginAccesCorrectAsync(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return false;

            bool passValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passValid)
                return false;

            return true;
        }

        public async Task<Tokens> LoginAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            var result = _tokenStoreRepository.GenerateToken(user, roles);
            return result;
        }


        public async Task<IdentityResult> RegisterAsync(Register model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is not null)
            {
                return null;
            }

            user = new Person
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            return await _userManager.CreateAsync(user, model.Password);
        }


        public async Task<Tokens> RefreshToken()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);
            return _tokenStoreRepository.GenerateToken(user, roles);
        }
    }
}
