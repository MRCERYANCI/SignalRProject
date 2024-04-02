using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.UILayoutsComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
