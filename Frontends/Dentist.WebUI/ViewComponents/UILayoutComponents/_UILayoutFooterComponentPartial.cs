using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
