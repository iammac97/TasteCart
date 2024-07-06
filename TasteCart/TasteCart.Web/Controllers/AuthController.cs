using Microsoft.AspNetCore.Mvc;
using TasteCart.Web.Models;
using TasteCart.Web.Service.IService;

namespace TasteCart.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
