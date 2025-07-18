using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Entities;
using MinimalAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPI.Services
{
    public class TokenServiceImp(IConfiguration configuration) : TokenService
    {
        public Task<string> GenerateRefreshTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var encodingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var tokenCredentials = new SigningCredentials(encodingKey, SecurityAlgorithms.HmacSha256);

            var tokenPayload = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: tokenCredentials
            );
            var newToken = new JwtSecurityTokenHandler().WriteToken(tokenPayload);
            return await Task.FromResult(newToken);
        }
    }
}
