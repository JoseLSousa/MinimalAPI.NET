using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.DTOs;
using MinimalAPI.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {

        public async Task<string> LoginAsync(LoginUserDto user)
        {
            var foundUser = await context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email && u.PasswordHash == user.Password);

            if (foundUser is null) throw new UnauthorizedAccessException("Invalid email or password.");

            return foundUser.Email;
        }

        public async Task RegisterAsync(RegisterUserDto user)
        {
            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.Password
            });

            await context.SaveChangesAsync();
        }
    }
}
