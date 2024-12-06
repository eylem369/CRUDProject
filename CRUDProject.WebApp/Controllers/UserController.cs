using CRUDProject.Service.Services.Contract;
using CRUDProject.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace CRUDProject.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly int _userId;
        private readonly IHttpContextAccessor _context;
        private readonly IWebHostEnvironment _webHost;
        public UserController(IAppUserService userService, IHttpContextAccessor context, IWebHostEnvironment webHost)
        {
            _userService = userService;
            _context = context;
            _userId = Convert.ToInt32(_context.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            _webHost = webHost;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditUser()
        {
            var user = await _userService.GetByIdAsync(_userId);
            UpdateAppUserViewModel model = new()
            {
                File = null,
                Id = user.Id,
                Username = user.Username
            };
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUser(UpdateAppUserViewModel model)
        {
            var user = await _userService.GetByIdAsync(model.Id);
            user.Username = model.Username;
            if (model.File is not null && model.File.Length > 0)
            {
                var uploadPath = Path.Combine(_webHost.WebRootPath, "UserImages");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var filePath = Path.Combine(uploadPath, model.File.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {

                    await model.File.CopyToAsync(stream);
                    user.ImagePath = $"/{model.File.FileName}";
                }
                await _userService.UpdateAsync(user);
                var claimsIden = HttpContext.User.Identity as ClaimsIdentity;
                Response.Cookies.Delete("profileImage");
                Response.Cookies.Append("profileImage", user.ImagePath);
                claimsIden.RemoveClaim(claimsIden.FindFirst(x => x.Type == "image"));
                claimsIden.AddClaim(new Claim("image", user.ImagePath));
            }
            return View(model);
        }
    }
}
