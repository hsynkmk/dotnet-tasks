using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
