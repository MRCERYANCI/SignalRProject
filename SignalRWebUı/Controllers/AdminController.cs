using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
