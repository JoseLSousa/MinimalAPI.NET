using MinimalAPI.Entities;

namespace MinimalAPI.Interfaces
{
    public interface TokenService
    {
        Task<string> GenerateTokenAsync(User user);
        Task<string> GenerateRefreshTokenAsync(User user);
    }
}
