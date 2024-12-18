using LibraryManagement.Application.Common.Utility;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(string roleId)
        {
            if (String.IsNullOrEmpty(roleId))
            {
                //create
                return View();
            }
            else
            {
                //update
                var objFromDb = _context.Roles.FirstOrDefault(u => u.Id == roleId);
                return View(objFromDb);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(IdentityRole roleObj)
        {
            if (await _roleManager.RoleExistsAsync(roleObj.Name))
            {
                //error
            }
            if (String.IsNullOrEmpty(roleObj.NormalizedName))
            {
                //create
                await _roleManager.CreateAsync(new IdentityRole() { Name = roleObj.Name });
                TempData["success"] = "Role created successfully";
            }
            else
            {
                //update
                var objFromDb = _context.Roles.FirstOrDefault(u => u.Id == roleObj.Id);
                objFromDb.Name = roleObj.Name;
                objFromDb.NormalizedName = roleObj.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(objFromDb);
                TempData["success"] = "Role updated successfully";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string roleId)
        {

            var objFromDb = _context.Roles.FirstOrDefault(u => u.Id == roleId);
            if (objFromDb != null)
            {
                var userRolesForThisRole = _context.UserRoles.Where(u => u.RoleId == roleId).Count();
                if (userRolesForThisRole > 0)
                {
                    TempData["error"] = "Cannot delete this role, since there are users assigned to this role.";
                    return RedirectToAction(nameof(Index));
                }

                var result = await _roleManager.DeleteAsync(objFromDb);
                TempData["success"] = "Role deleted successfully";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
