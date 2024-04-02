using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUı.ViewComponents.UILayoutsComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
