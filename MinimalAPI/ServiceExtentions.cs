using MinimalAPI.Data;

namespace MinimalAPI
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNpgsql<AppDbContext>(configuration.GetConnectionString("DefaultConnection"));
            return services;
        }
    }
}
