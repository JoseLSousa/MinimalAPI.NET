using MinimalAPI.DTOs;

namespace MinimalAPI.Interfaces
{
    public interface UserRepository
    {
        Task RegisterAsync(RegisterUserDto user);
        Task<string> LoginAsync(LoginUserDto user);
    }
}
