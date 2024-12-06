using CRUDProject.Entities.DTOs;
using CRUDProject.Service.Services.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUDProject.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService _userService;

        public AuthController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserLoginRequestModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel requestModel)
        {
            var user = await _userService.Login(requestModel);
            if (user is not null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, user.Role));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim("image", user.ImagePath));
                claims.Add(new Claim("username", user.Username));


                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                AuthenticationProperties prop = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, prop);
                Response.Cookies.Append("isActive", user.IsActive.ToString(), new CookieOptions() { Expires = DateTimeOffset.Now.AddHours(2) });


                Response.Cookies.Append("profileImage", user.ImagePath);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var cookie = Request.Cookies.Where(x => x.Key == "isActive").First();
            Response.Cookies.Delete(cookie.Key);
            return RedirectToAction("Index");
        }
    }
}
