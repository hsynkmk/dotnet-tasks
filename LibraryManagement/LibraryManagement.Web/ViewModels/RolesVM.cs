using LibraryManagement.Domain.Entities;

namespace IdentityManager.Models.ViewModels
{
    public class RolesVM
    {
        public RolesVM()
        {
            RolesList = [];
        }
        public ApplicationUser User { get; set; }
        public List<RoleSelection> RolesList { get; set; }
    }


    public class RoleSelection
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}