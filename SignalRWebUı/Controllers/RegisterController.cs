using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalREntityLayer.Entities;
using SignalRWebUı.Dtos.IdentityDtos;

namespace SignalRWebUı.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                SurName = registerDto.Surname,
                UserName = registerDto.UserName,
                Email = registerDto.Mail,
                PhoneNumber = registerDto.Phone
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
			}

            return View();
        }
    }
}
