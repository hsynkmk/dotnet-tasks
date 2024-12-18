using IdentityManager.Models.ViewModels;
using LibraryManagement.Application.Common.Utility;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var userList = _context.ApplicationUsers.ToList();
            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();
            foreach (var user in userList)
            {
                var user_role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if (user_role == null)
                {
                    user.Role = "none";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == user_role.RoleId).Name;
                }
            }
            return View(userList);
        }

        public async Task<IActionResult> ManageRole(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            List<string> exsitingUserRoles = await _userManager.GetRolesAsync(user) as List<string>;
            var model = new RolesVM()
            {
                User = user
            };
            foreach (var role in _roleManager.Roles)
            {
                RoleSelection roleSelection = new()
                {
                    RoleName = role.Name
                };
                if (exsitingUserRoles.Any(c => c == role.Name))
                {
                    roleSelection.IsSelected = true;
                }
                model.RolesList.Add(roleSelection);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(RolesVM rolesViewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(rolesViewModel.User.Id);
            if (user == null)
            {
                return NotFound();
            }
            var oldUserRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, oldUserRoles);
            if (!result.Succeeded)
            {
                TempData["error"] = "Error while removing roles";
                return View(rolesViewModel);
            }

            result = await _userManager.AddToRolesAsync(user,
                rolesViewModel.RolesList.Where(x => x.IsSelected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                TempData["error"] = "Error while adding roles";
                return View(rolesViewModel);
            }
            TempData["success"] = "Roles assigned successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
