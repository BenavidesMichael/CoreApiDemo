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
    public class TokenStoreRepository : ITokenStoreRepository
    {
        private readonly JWTOptions _settingsConfig;

        public TokenStoreRepository(IOptions<JWTOptions> appSettings)
        {
            _settingsConfig = appSettings.Value;
        }

        private IEnumerable<Claim> CreateClaims(IdentityUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private DateTime GetExpiration()
        {
            return DateTime.UtcNow.AddMinutes(5);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsConfig.SecretKeyToken));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GetTokenValidationParams(IdentityUser user, IList<string> roles)
        {
            return new JwtSecurityToken(
                issuer: _settingsConfig.Issuer,
                audience: _settingsConfig.Audience,
                claims: CreateClaims(user, roles),
                expires: GetExpiration(),
                signingCredentials: GetSigningCredentials());
        }



        public Tokens GenerateToken(IdentityUser user, IList<string> roles)
        {
            var token = GetTokenValidationParams(user, roles);
            return new Tokens 
            { 
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token), 
                Expire = GetExpiration()
            };
        }

        public Tokens RefreshToken(IdentityUser user, IList<string> roles)
        {
            var token = GetTokenValidationParams(user, roles);
            return new Tokens
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expire = GetExpiration()
            };
        }
    }
}
