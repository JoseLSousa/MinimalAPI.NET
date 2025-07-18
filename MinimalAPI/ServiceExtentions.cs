using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Entities;
using MinimalAPI.Interfaces;
using MinimalAPI.Repositories;
using MinimalAPI.Services;

namespace MinimalAPI
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserRepository, UserRepositoryImp>();

            services.AddScoped<TokenService, TokenServiceImp>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();
            services.AddAuthorization();
            return services;
        }
    }
}
