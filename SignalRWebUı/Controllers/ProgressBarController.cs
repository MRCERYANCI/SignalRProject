using Microsoft.AspNetCore.Mvc;
using SignalRWebUı.Models;

namespace SignalRWebUı.Controllers
{
	public class ProgressBarController : Controller
	{
		OtpNotificationSecurity notificationSecurity = new OtpNotificationSecurity();
        public IActionResult Index()
		{
			ViewBag.Url = notificationSecurity.OtpStatus;
			return View();
		}
	}
}
