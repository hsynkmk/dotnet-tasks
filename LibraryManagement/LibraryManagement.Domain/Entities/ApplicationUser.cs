using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // We will add custom properties if needed
        string Nickname { get; set; }

        [NotMapped]
        public string RoleId { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
