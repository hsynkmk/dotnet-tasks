using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // We will add custom properties if needed
        string Nickname { get; set; }
    }
}
