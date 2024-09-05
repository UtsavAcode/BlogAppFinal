using Microsoft.AspNetCore.Identity;

namespace BlogApp.Model.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
