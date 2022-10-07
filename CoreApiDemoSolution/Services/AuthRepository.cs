using CoreApiDemo.Contracts;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreApiDemo.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SettingsConfig _settingsConfig;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository(
            IOptions<SettingsConfig> appSettings,
            UserManager<IdentityUser> userManager)
        {
            _settingsConfig = appSettings.Value;
            _userManager = userManager;
        }


        public async Task<AuthResponse> LoginAsync(string email)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settingsConfig.SecretKeyToken);

            // claims 
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            // End - claims 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
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

    }
}
