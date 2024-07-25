using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutProfileComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
