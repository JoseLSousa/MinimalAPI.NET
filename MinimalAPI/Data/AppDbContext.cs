using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = default!;
    }
}
