using CoreApiDemo.Contracts;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiDemo.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SettingsConfig _settingsConfig;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthRepository(
            IOptions<SettingsConfig> appSettings,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _settingsConfig = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<AuthResponse> LoginAsync(Login model)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settingsConfig.SecretKeyToken);

            var user = await _userManager.FindByNameAsync(model.Email);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptToken = tokenHandler.WriteToken(token);

            return new AuthResponse()
            {
                Expires = (DateTime)tokenDescriptor.Expires,
                AccessToken = encryptToken
            };
        }


        public async Task<IdentityResult> RegisterAsync(Register model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            return await _userManager.CreateAsync(user, model.Password);
        }


        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<bool> IsLoginAccesCorrectAsync(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null)
                return false;

            bool passValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passValid)
                return false;

            return true;
        }


    }
}
