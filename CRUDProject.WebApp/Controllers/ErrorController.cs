using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
