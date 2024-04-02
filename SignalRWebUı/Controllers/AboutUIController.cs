using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    [AllowAnonymous]
    public class AboutUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
