using Lgym.Services.Configurations;
using Lgym.Services.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lgym.Services.Security
{
    public static class JwtGenerator
    {
        public static string Generate(User user, JwtSettings jwtSettings, string[] userClaims)
        {
            // Główne parametry tokena
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tworzymy listę "claims" (dowolne dane, np. Id, Email)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            claims.AddRange(userClaims.Select(x => new Claim(x, "true")));

            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            var expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpiresInMinutes);

            // Budujemy token
            var tokenDescriptor = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: creds
            );

            // Zamieniamy w obiekt string (np. "eyJhbGc...")
            string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return jwt;
        }
    }
}
