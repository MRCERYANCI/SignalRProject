using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalREntityLayer.Entities;

namespace SignalRWebUı.ViewComponents.LayoutComponents
{
	public class _LayoutSideBarPartialComponent : ViewComponent
	{
        private readonly UserManager<AppUser> _userManager;

        public _LayoutSideBarPartialComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.SurName;
            ViewBag.Mail = values.Email;

            return View();
		}
	}
}
