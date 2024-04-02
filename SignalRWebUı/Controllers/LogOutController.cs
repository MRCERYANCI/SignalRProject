using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalREntityLayer.Entities;

namespace SignalRWebUı.Controllers
{
    public class LogOutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogOutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Uye", "Login");
        }
    }
}
