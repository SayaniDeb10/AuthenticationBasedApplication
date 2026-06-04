using Microsoft.AspNetCore.Mvc;

namespace FirstMVCWebApp.Controllers
{
    public class AuthController : Controller//MVC controller, if here will ControllerBase then it will be Api controller
    {
        public IActionResult Login() 
        //IActionResult -> returns view, redirect to action, content, json (Its returns 4 types of things)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
