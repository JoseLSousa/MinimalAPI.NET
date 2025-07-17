using MinimalAPI.DTOs;

namespace MinimalAPI.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(RegisterUserDto user);
        Task<string> LoginAsync(LoginUserDto user);
    }
}
