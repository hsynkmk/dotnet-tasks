using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return View();

            await _roleManager.CreateAsync(new IdentityRole(name));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return View();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            role.Name = name;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction(nameof(Index));
        }
    }

}
