using CRUDProject.Service.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var user = User;
            var result = await _productService.GetAllAsync();
            return View(result);
        }
        [Authorize(Roles ="standart,user")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
