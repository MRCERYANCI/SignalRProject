using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.DefaultComponents
{
	public class _DefaultMessageComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
