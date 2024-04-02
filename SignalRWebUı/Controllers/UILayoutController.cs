using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
