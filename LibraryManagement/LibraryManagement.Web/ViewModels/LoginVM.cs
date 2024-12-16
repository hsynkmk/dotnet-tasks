using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.ViewModels
{
    public class LoginVM
    {
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
