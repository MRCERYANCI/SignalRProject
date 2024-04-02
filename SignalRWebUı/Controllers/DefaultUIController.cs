using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.Controllers
{
    public class DefaultUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
