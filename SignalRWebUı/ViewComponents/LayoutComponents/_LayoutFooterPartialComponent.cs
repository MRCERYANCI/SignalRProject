using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.LayoutComponents
{
	public class LayoutFooterPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
