using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutMessageComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
