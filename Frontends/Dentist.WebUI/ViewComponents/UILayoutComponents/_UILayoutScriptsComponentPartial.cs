using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutScriptsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
