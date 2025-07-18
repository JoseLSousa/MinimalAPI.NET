using Microsoft.AspNetCore.Identity;
using MinimalAPI.DTOs;
using MinimalAPI.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Repositories
{
    public class UserRepositoryImp(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService) : Interfaces.UserRepository
    {
        public async Task<string> LoginAsync(LoginUserDto user)
        {
            var userEntity = await userManager.FindByEmailAsync(user.Email);
            if (userEntity is null) throw new Exception("User not found");

            var verifyIfPasswordIsValid = await signInManager.CheckPasswordSignInAsync(userEntity, user.Password, false);

            if (!verifyIfPasswordIsValid.Succeeded) throw new Exception("Invalid password");

            return await tokenService.GenerateTokenAsync(userEntity);

        }

        public async Task RegisterAsync(RegisterUserDto user)
        {
            var newUser = new User
            {
                UserName = user.Email,
                Email = user.Email,
                Name = user.Name
            };
            var result = await userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
