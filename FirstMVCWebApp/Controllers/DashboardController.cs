using Microsoft.AspNetCore.Mvc;

namespace FirstMVCWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
