using Microsoft.AspNetCore.Identity;

namespace MinimalAPI.Entities
{
    public sealed class User : IdentityUser
    {
        public string Name { get; set; } = default!;
    }
}
